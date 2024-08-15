using Application.Interfaces;
using Application.ViewModels.Requests;
using Domain.Entities;
using Domain.Interfaces.Repositories;
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
    public class ComentarioService : IComentarioService
    {
        private readonly ICommonRepositoryEF _commonRepository;

        public ComentarioService(ICommonRepositoryEF commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<CommonResponse> SalvarAsync(ComentarioSalvarRequest request)
        {
            Tarefa? tarefa = await _commonRepository.ObterPorIdAsync<Tarefa>(request.TarefaId, tarefa => tarefa.Include(x => x.Comentarios));

            if(tarefa == null)
                return CommonResponse.ErroBuilder(CommonMsgError.ENTIDADE_NAO_ENCONTRADA);

            _commonRepository.RastrearEntidade(tarefa);

            tarefa.Comentarios.Add(new Comentario { Descricao = request.Comentarios });

            await _commonRepository.SalvarAlteracoesAsync();

            return CommonResponse.SucessoBuilder();

        }
    }
}
