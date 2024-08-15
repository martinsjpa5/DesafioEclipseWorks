
using System.ComponentModel.DataAnnotations;
using Utils.Models;

namespace Application.ViewModels.Requests
{
    public class ProjetoEditarRequest
    {
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public int Id { get; set; }
        [Required(ErrorMessage = CommonMsgDataAnnotations.MsgRequired)]
        public string Nome { get; set; }
    }
}
