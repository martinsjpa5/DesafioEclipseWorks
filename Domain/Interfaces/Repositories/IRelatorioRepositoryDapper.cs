using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRelatorioRepositoryDapper
    {
        Task<RelatorioDesempenho> ObterRelatorioDesempenhoAsync(Guid criadoPor);
    }
}
