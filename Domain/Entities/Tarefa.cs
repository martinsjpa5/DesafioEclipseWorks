using Domain.Enum;
using Utils.Response;

namespace Domain.Entities
{
    public class Tarefa : Entidade
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public EPrioridadeTarefa Prioridade { get; set; }
        public EStatusTarefa Status { get; set; } = EStatusTarefa.PENDENTE;
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public ICollection<HistoricoAlteracaoTarefa> HistoricosAlteracoes { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        public CommonResponse Editar(string titulo, string descricao, DateTime dataVencimento, EStatusTarefa status)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Status = status;
            AtualizadoEm = DateTime.Now;
            return CommonResponse.SucessoBuilder();
        }

        public override CommonResponse EhValida()
        {
            return CommonResponse.SucessoBuilder();
        }
    }
}
