using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface ICommonRepositoryEF
    {
        public bool RastrearEntidade<T>(T entidade) where T : Entidade;
        public Task<bool> AdicionarEntidadeAsync<T>(T entidade) where T : Entidade;
        public Task<bool> AdicionarEntidadesAsync<T>(List<T> entidades) where T : Entidade;
        public bool RastrearEntidades<T>(ICollection<T> entidades) where T : Entidade;
        public Task<ICollection<T>> ObterTodosAsync<T>() where T : Entidade;
        public Task<ICollection<T>> ObterTodosAsync<T>(ICollection<string> propriedadesRelacionamentos) where T : Entidade;
        public Task<T?> ObterPorIdAsync<T>(int id) where T : Entidade;
        public Task<ICollection<T>> ObterPorIdsAsync<T>(ICollection<int> ids) where T : Entidade;
        public Task<T?> ObterPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade;
        public Task<ICollection<T>> ObterTodosPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade;
        public Task<bool> EntidadeExisteAsync<T>(int id) where T : Entidade;
        public Task<T?> ObterPorIdAsync<T>(int id, ICollection<string> propriedadesRelacionamentos) where T : Entidade;
        public Task<int> SalvarAlteracoesAsync();
    }
}
