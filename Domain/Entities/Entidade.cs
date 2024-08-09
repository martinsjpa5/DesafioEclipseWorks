
using Utils.Response;

namespace Domain.Entities
{
    public abstract class Entidade
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }

        public abstract CommonResponse EhValida();
    }
}
