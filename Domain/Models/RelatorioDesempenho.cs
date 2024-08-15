

using Domain.Interfaces.Caching.Interfaces;

namespace Domain.Models
{
    public class RelatorioDesempenho : ICommonCaching
    {
        public Guid Usuario { get; set; }
        public int TarefasConcluidasUltimos30Dias { get; set; }

        public string ObterKey()
        {
            return $"{typeof(RelatorioDesempenho).Name}-{Usuario}";
        }
    }
}
