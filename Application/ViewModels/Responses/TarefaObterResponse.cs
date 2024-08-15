using Domain.Enum;

namespace Application.ViewModels.Responses
{
    public class TarefaObterResponse : EntidadeCommonResponse
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public EPrioridadeTarefa Prioridade { get; set; }
        public EStatusTarefa Status { get; set; }
        public int ProjetoId { get; set; }
        public ICollection<HistoricoAlteracaoTarefaObterResponse> HistoricosAlteracoes { get; set; }
    }
}
