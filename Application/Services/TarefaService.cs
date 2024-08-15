using Application.Interfaces;
using Application.ViewModels.Requests;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using ExternalServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Models;
using Utils.Response;

namespace Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ICommonRepositoryEF _commonRepository;
        private readonly ITarefaDomainService _tarefaDomainService;
        private readonly IAuthExternalService _authExternalService;

        public TarefaService(ICommonRepositoryEF commonRepository, ITarefaDomainService tarefaDomainService, IAuthExternalService authExternalService)
        {
            _commonRepository = commonRepository;
            _tarefaDomainService = tarefaDomainService;
            _authExternalService = authExternalService;
        }

        public async Task<CommonResponse> EditarAsync(TarefaEditarRequest request)
        {
            Tarefa? entidade = await  _commonRepository.ObterPorIdAsync<Tarefa>(request.Id);

            if (entidade == null)
                return CommonResponse.ErroBuilder(CommonMsgError.ENTIDADE_NAO_ENCONTRADA);

            _commonRepository.RastrearEntidade(entidade);

            entidade.Editar(request.Titulo, request.Descricao, request.DataVencimento, request.Status);

            CommonResponse commonResponse = await _tarefaDomainService.EditarAsync(entidade, _authExternalService.ObterAnalista());

            if (commonResponse.Sucesso is false)
                return commonResponse;

            await _commonRepository.SalvarAlteracoesAsync();

            return CommonResponse.SucessoBuilder();

        }

        public async Task<CommonResponse> SalvarAsync(TarefaSalvarRequest request)
        {
            Tarefa tarefaEntidade = new() { Titulo = request.Titulo, Descricao = request.Descricao, DataVencimento = request.DataVencimento, ProjetoId = request.ProjetoId, Prioridade = request.Prioridade };

            Projeto? projetoEntidade = await _commonRepository.ObterPorIdAsync<Projeto>(request.ProjetoId, query => query.Include(x => x.Tarefas));

            if(projetoEntidade == null)
                return CommonResponse.ErroBuilder(CommonMsgError.ENTIDADE_NAO_ENCONTRADA);

            CommonResponse responseAdicionarTarefaNoProjeto = projetoEntidade.AdicionarTarefa(tarefaEntidade);

            if (responseAdicionarTarefaNoProjeto.Sucesso is false)
                return responseAdicionarTarefaNoProjeto;

            await _commonRepository.AdicionarEntidadeAsync(tarefaEntidade);

            await _commonRepository.SalvarAlteracoesAsync();

            return CommonResponse.SucessoBuilder();
        }
    }
}
