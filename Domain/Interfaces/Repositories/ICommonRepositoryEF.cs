using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface ICommonRepositoryEF
    {
        bool RastrearEntidade<T>(T entidade) where T : Entidade;
        Task<bool> AdicionarEntidadeAsync<T>(T entidade) where T : Entidade;
        Task<bool> AdicionarEntidadesAsync<T>(List<T> entidades) where T : Entidade;
        bool RastrearEntidades<T>(ICollection<T> entidades) where T : Entidade;

        bool DeletarEntidade<T>(T entidade) where T : Entidade;
        Task<ICollection<T>> ObterTodosAsync<T>() where T : Entidade;
        Task<T?> ObterPorIdAsync<T>(int id) where T : Entidade;
        Task<ICollection<T>> ObterPorIdsAsync<T>(ICollection<int> ids) where T : Entidade;
        Task<T?> ObterPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade;
        Task<ICollection<T>> ObterTodosPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade;
        Task<bool> EntidadeExisteAsync<T>(int id) where T : Entidade;
        Task<int> SalvarAlteracoesAsync();
        Task<ICollection<T>> ObterTodosAsync<T>(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes) where T : Entidade;
        Task<T?> ObterPorIdAsync<T>(int id, params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes) where T : Entidade;
    }
}
