using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class TarefaSalvarRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public EPrioridadeTarefa Prioridade { get; set; }

        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public int ProjetoId { get; set; }

        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public DateTime DataVencimento { get; set; }
    }
}
