using Utils.Response;

namespace Domain.Entities
{
    public class Comentario : Entidade
    {
        public string Descricao { get; set; }

        public Tarefa Tarefa { get; set; }
        public int TarefaId { get; set; }

        public override CommonResponse EhValida()
        {
            return CommonResponse.SucessoBuilder();
        }
    }
}
