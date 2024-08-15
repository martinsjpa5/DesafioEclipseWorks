using Domain.Entities;
using Domain.Interfaces.Caching.Interfaces;
using Domain.Interfaces.Caching.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Newtonsoft.Json;
using Utils.Response;

namespace Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        private readonly ICommonRepositoryEF _commonRepository;
        private readonly ICommonCachingRepository _CommonCachingRepository;

        public TarefaDomainService(ICommonRepositoryEF commonRepository, ICommonCachingRepository commonCachingRepository)
        {
            _commonRepository = commonRepository;
            _CommonCachingRepository = commonCachingRepository;
        }

        public async Task<CommonResponse> EditarAsync(Tarefa tarefa, CommonUser user)
        {
            HistoricoAlteracaoTarefa historicoTarefa = new()
            {
                TarefaId = tarefa.Id,
                CriadoPor = user.Id,
                Alteracoes = JsonConvert.SerializeObject(tarefa),
            };

            await _commonRepository.AdicionarEntidadeAsync(historicoTarefa);

            if(EssaEdicaoAlteraResultadoRelatorio(tarefa))
                await ResetarCachingRelatorio(user.Id);

            return CommonResponse.SucessoBuilder();
        }

        private static bool EssaEdicaoAlteraResultadoRelatorio(Tarefa tarefa)
        {
            if (tarefa.Status == Enum.EStatusTarefa.CONCLUIDA)
                return true;
            return false;
        }

        private async Task<bool> ResetarCachingRelatorio(Guid usuario)
        {
            RelatorioDesempenho relatorio = new() { Usuario = usuario };
            await _CommonCachingRepository.RemoveAsync(relatorio);
            return true;
        }
    }
}
