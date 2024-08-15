using Application.ViewModels.Requests;
using Utils.Response;

namespace Application.Interfaces
{
    public interface ITarefaService
    {
        public Task<CommonResponse> EditarAsync(TarefaEditarRequest request);
        public Task<CommonResponse> SalvarAsync(TarefaSalvarRequest request);
    }
}
