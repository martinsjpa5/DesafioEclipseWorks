
using Domain.Models;

namespace ExternalServices.Interfaces
{
    public interface IAuthExternalService
    {
        CommonUser ObterAnalista();
        CommonUser ObterGerente();
        List<CommonUser> ObterAnalistas();
        List<CommonUser> ObterGerentes();
    }
}
