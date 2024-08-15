
using Domain.Entities;

namespace Application.ViewModels.Responses
{
    public class ProjetoObterResponse : EntidadeCommonResponse
    {
        public string Nome { get; set; }
        public List<TarefaObterResponse> Tarefas { get; set; }

        public static List<ProjetoObterResponse> Mapear(ICollection<Projeto> projetos)
        {
            return projetos.Select(projeto => new ProjetoObterResponse
            {
                Id = projeto.Id,
                AtualizadoEm = projeto.AtualizadoEm,
                CriadoEm = projeto.CriadoEm,
                Tarefas = projeto.Tarefas.Select(tarefa =>
                new TarefaObterResponse
                {
                    Id = tarefa.Id,
                    Descricao = tarefa.Descricao,
                    Prioridade = tarefa.Prioridade,
                    Titulo = tarefa.Titulo,
                    DataVencimento = tarefa.DataVencimento,
                    Status = tarefa.Status,
                    HistoricosAlteracoes = tarefa.HistoricosAlteracoes.Select(historico =>
                    new HistoricoAlteracaoTarefaObterResponse
                    {
                        Alteracoes = historico.Alteracoes,
                        CriadoEm = historico.CriadoEm,
                        Id = historico.Id,
                        CriadoPor = historico.CriadoPor
                    })
                    .ToList()
                })
                .ToList()
            }).ToList();
        }

    }
}
