
using Utils.Response;

namespace Domain.Entities
{
    public class Projeto : Entidade
    {
        public string Nome { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }


        public CommonResponse Editar(string nome)
        {
            Nome = nome;
            AtualizadoEm = DateTime.Now;

            return CommonResponse.SucessoBuilder();
        }
        public CommonResponse AdicionarTarefa(Tarefa tarefa)
        {
            CommonResponse response = CommonResponse.SucessoBuilder();

            if (Tarefas.Count == 20)
                response.AdicionarErro("O Projeto Excedeu o Limite máximo que é 20");
            else
                Tarefas.Add(tarefa);

            return response;
        }

        public CommonResponse PodeDeletar()
        {
            var existeTarefasPendentes = Tarefas.Any(tarefa => tarefa.Status != Enum.EStatusTarefa.CONCLUIDA);

            if (existeTarefasPendentes)
                return CommonResponse.ErroBuilder("Esse Projeto não pode ser deletado pois existem tarefas pendentes");

            return CommonResponse.SucessoBuilder();
        }

        public override CommonResponse EhValida()
        {
            CommonResponse response = CommonResponse.SucessoBuilder();

            return response;
        }
    }
}
