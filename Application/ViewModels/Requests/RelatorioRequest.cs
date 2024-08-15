using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class RelatorioRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public Guid GerenteId { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public Guid AnalistaId { get; set; }
    }
}
