

using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class ComentarioSalvarRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string? Comentarios { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public int TarefaId { get; set; }

    }
}
