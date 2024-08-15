
using Utils.Response;

namespace Domain.Entities
{
    public abstract class Entidade
    {
        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; } = DateTime.Now;
        public DateTime? AtualizadoEm { get; protected set; }
        public abstract CommonResponse EhValida();

    }
}
