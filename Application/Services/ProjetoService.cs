using Application.Interfaces;
using Application.ViewModels.Requests;
using Application.ViewModels.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Utils.Models;
using Utils.Response;

namespace Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly ICommonRepositoryEF _commonRepository;

        public ProjetoService(ICommonRepositoryEF commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<CommonResponse> DeletarAsync(int projetoId)
        {
            Projeto? entidade = await _commonRepository.ObterPorIdAsync<Projeto>(projetoId, x => x.Include(y => y.Tarefas));

            if (entidade == null)
                return CommonResponse.ErroBuilder(CommonMsgError.ENTIDADE_NAO_ENCONTRADA);

            CommonResponse responsePodeDeletar = entidade.PodeDeletar();

            if (responsePodeDeletar.Sucesso is false)
                return CommonResponse.ErroBuilder(responsePodeDeletar.Erros);

            _commonRepository.DeletarEntidade(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return CommonResponse.SucessoBuilder();
        }

        public async Task<CommonResponse> EditarAsync(ProjetoEditarRequest request)
        {
            Projeto? entidade = await _commonRepository.ObterPorIdAsync<Projeto>(request.Id);

            if (entidade == null)
                return CommonResponse.ErroBuilder(CommonMsgError.ENTIDADE_NAO_ENCONTRADA);

            _commonRepository.RastrearEntidade(entidade);

            entidade.Editar(request.Nome);

            await _commonRepository.SalvarAlteracoesAsync();

            return CommonResponse.SucessoBuilder();

        }

        public async Task<CommonGenericResponse<List<ProjetoObterResponse>>> ObterTodosAsync()
        {
            ICollection<Projeto> projetos = await _commonRepository.ObterTodosAsync<Projeto>(query => query.Include(x => x.Tarefas), query => query.Include(x => x.Tarefas).ThenInclude(x => x.HistoricosAlteracoes));

            List<ProjetoObterResponse> response = ProjetoObterResponse.Mapear(projetos);

            return CommonGenericResponse<List<ProjetoObterResponse>>.SucessoBuilder(response);
        }

        public async Task<CommonResponse> SalvarAsync(ProjetoSalvarRequest request)
        {
            Projeto entidade = new()
            {
                Nome = request.Nome,
                Tarefas = request.Tarefas?.Select(tarefa => new Tarefa { Titulo = tarefa.Titulo, DataVencimento = tarefa.DataVencimento, Descricao = tarefa.Descricao,  Prioridade = tarefa.Prioridade }).ToList()
            };

            CommonResponse responseValidate = entidade.EhValida();

            if (responseValidate.Sucesso is false)
                return responseValidate;

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return responseValidate;
        }
    }
}
