using Application.ViewModels.Requests;
using Utils.Response;

namespace Application.Interfaces
{
    public interface IComentarioService
    {
        Task<CommonResponse> SalvarAsync(ComentarioSalvarRequest request);
    }
}
