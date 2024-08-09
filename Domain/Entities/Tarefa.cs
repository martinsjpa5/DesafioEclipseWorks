using Domain.Enum;
using Utils.Response;

namespace Domain.Entities
{
    public class Tarefa : Entidade
    {
        public string Detalhes { get; set; }
        public EPrioridadeTarefa Prioridade { get; set; }
        public EStatusTarefa Status { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public ICollection<HistoricoAlteracaoTarefa> HistoricosAlteracoes { get; set; }

        public override CommonResponse EhValida()
        {
            return CommonResponse.SucessoBuilder();
        }
    }
}
