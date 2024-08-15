
using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class ProjetoSalvarRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Nome { get; set; }
        public ICollection<TarefaSalvarRequest>? Tarefas { get; set; }
    }
}
