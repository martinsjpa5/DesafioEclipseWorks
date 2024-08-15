using Application.ViewModels.Requests;
using Application.ViewModels.Responses;
using Domain.Entities;
using Utils.Response;

namespace Application.Interfaces
{
    public interface IProjetoService
    {
        Task<CommonGenericResponse<List<ProjetoObterResponse>>> ObterTodosAsync();
        Task<CommonResponse> SalvarAsync(ProjetoSalvarRequest request);
        Task<CommonResponse> EditarAsync(ProjetoEditarRequest request);
        Task<CommonResponse> DeletarAsync(int projetoId);
    }
}
