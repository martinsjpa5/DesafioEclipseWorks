
namespace Application.ViewModels.Responses
{
    public class HistoricoAlteracaoTarefaObterResponse : EntidadeCommonResponse
    {
        public string Alteracoes { get; set; }
        public Guid CriadoPor { get; set; }
        public int TarefaId { get; set; }
    }
}
