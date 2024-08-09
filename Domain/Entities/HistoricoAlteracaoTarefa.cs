using Utils.Response;

namespace Domain.Entities
{
    public class HistoricoAlteracaoTarefa : Entidade
    {

        public string Alteracoes { get; set; }
        public string CriadoPor { get; set; }

        public Tarefa Tarefa { get; set; }
        public int TarefaId { get; set; }
        public override CommonResponse EhValida()
        {
           return CommonResponse.SucessoBuilder();
        }
    }
}
