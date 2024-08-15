using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class TarefaEditarRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public int Id { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public DateTime DataVencimento { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public EStatusTarefa Status { get; set; }

    }
}
