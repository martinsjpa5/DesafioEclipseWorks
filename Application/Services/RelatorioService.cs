
using Application.Interfaces;
using Application.ViewModels.Requests;
using Domain.Interfaces.Caching.Repositories;
using Domain.Interfaces.Queues;
using Domain.Interfaces.Repositories;
using Domain.Models;
using ExternalServices.Interfaces;
using Utils.Response;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepositoryDapper _relatorioRepositoryDapper;
        private readonly IAuthExternalService _authExternalService;
        private readonly ICommonCachingRepository _commonCachingRepository;
        private readonly IRelatorioQueue _relatorioQueue;

        public RelatorioService(IRelatorioRepositoryDapper relatorioRepositoryDapper, IAuthExternalService authExternalService, ICommonCachingRepository commonCachingRepository, IRelatorioQueue relatorioQueue)
        {
            _relatorioRepositoryDapper = relatorioRepositoryDapper;
            _authExternalService = authExternalService;
            _commonCachingRepository = commonCachingRepository;
            _relatorioQueue = relatorioQueue;
        }

        public async Task<CommonGenericResponse<bool>> GerarRelatorioDesempenhoAsync(RelatorioRequest request)
        {
            RelatorioDesempenho result = await _relatorioRepositoryDapper.ObterRelatorioDesempenhoAsync(request.AnalistaId);

            DateTime now = DateTime.Now;
            DateTime midnightTonight = now.Date.AddDays(1);

            TimeSpan timeUntilMidnight = midnightTonight - now; 

            await _commonCachingRepository.SetAsync(result, timeUntilMidnight);

            return CommonGenericResponse<bool>.SucessoBuilder(true);
        }

        public async Task<CommonGenericResponse<RelatorioDesempenho>> ObterRelatorioDesempenhoAsync(RelatorioRequest request)
        {
            if (_authExternalService.ObterGerentes().FirstOrDefault(gerente => gerente.Id == request.GerenteId) == null)
                return CommonGenericResponse<RelatorioDesempenho>.ErroBuilder("O GerenteId informado não é de um gerente portanto essa funcionalidade não poderá ser utilizada");

            RelatorioDesempenho relatorio = new() { Usuario = request.AnalistaId };

            var result = await _commonCachingRepository.GetAsync<RelatorioDesempenho>(relatorio.ObterKey());

            if (result == null)
                return CommonGenericResponse<RelatorioDesempenho>.ErroBuilder("Seu Relatório ainda não foi gerado, você deve gerar ele no endpoint GerarRelatorio e depois executar esse endpoint novamente. Assim que o seu relatório estiver pronto deverá retornar algo aqui, caso contrário contate o suporte do sistema");

            return CommonGenericResponse<RelatorioDesempenho>.SucessoBuilder(result);


        }

        public async Task<CommonGenericResponse<string>> PedirParaGerarRelatorioAsync(RelatorioRequest request)
        {
            if (_authExternalService.ObterGerentes().FirstOrDefault(gerente => gerente.Id == request.GerenteId) == null)
                return CommonGenericResponse<string>.ErroBuilder("O GerenteId informado não é de um gerente portanto essa funcionalidade não poderá ser utilizada");

            await _relatorioQueue.PublishMessageAsync(new Domain.Contracts.Queues.RelatorioMessage { Usuario = request.AnalistaId });

            return CommonGenericResponse<string>.SucessoBuilder("Pedido de Geração de Relatório realizado com sucesso, em breve seu relatório estará pronto para ser visualizado");
        }
    }
}
