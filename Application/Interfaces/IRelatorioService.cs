
using Application.ViewModels.Requests;
using Domain.Models;
using Utils.Response;

namespace Application.Interfaces
{
    public interface IRelatorioService
    {
        public Task<CommonGenericResponse<RelatorioDesempenho>> ObterRelatorioDesempenhoAsync(RelatorioRequest request);
        public Task<CommonGenericResponse<bool>> GerarRelatorioDesempenhoAsync(RelatorioRequest request);

        public Task<CommonGenericResponse<string>> PedirParaGerarRelatorioAsync(RelatorioRequest request);
    }
}
