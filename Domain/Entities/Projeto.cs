
using Utils.Response;

namespace Domain.Entities
{
    public class Projeto : Entidade
    {
        public string Nome { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }

        public CommonResponse AdicionarTarefa(Tarefa tarefa)
        {
            CommonResponse response = CommonResponse.SucessoBuilder();

            if (Tarefas.Count == 20)
                response.AdicionarErro("O Projeto Excedeu o Limite máximo que é 20");
            else
                Tarefas.Add(tarefa);

            return response;
        }

        public override CommonResponse EhValida()
        {
            CommonResponse response = CommonResponse.SucessoBuilder();

            if (Nome.Contains("BR"))
                response.AdicionarErro("No final do nome do projeto deve haver a sigla BR");

            return response;
        }
    }
}
