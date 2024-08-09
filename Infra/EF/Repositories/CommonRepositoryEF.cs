using Domain.Entities;
using Domain.Repositories;
using Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.EF.Repositories
{
    public abstract class CommonRepositoryEF : ICommonRepositoryEF
    {
        protected readonly DatabaseContext _dataContext;
        private bool disposed = false;

        public CommonRepositoryEF(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AdicionarEntidadeAsync<T>(T entidade) where T : Entidade
        {
            await _dataContext.AddAsync(entidade);
            return true;
        }
        public async Task<bool> AdicionarEntidadesAsync<T>(List<T> entidades) where T : Entidade
        {
            await _dataContext.AddRangeAsync(entidades);
            return true;
        }

        public bool RastrearEntidade<T>(T entidade) where T : Entidade
        {
            _dataContext.Attach(entidade);
            return true;
        }

        public bool RastrearEntidades<T>(ICollection<T> entidades) where T : Entidade
        {
            _dataContext.AttachRange(entidades);
            return true;
        }

        public async Task<ICollection<T>> ObterTodosAsync<T>() where T : Entidade
        {
            var result = await _dataContext.Set<T>().ToListAsync();

            return result;
        }
        public async Task<T?> ObterPorIdAsync<T>(int id) where T : Entidade
        {
            var result = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<ICollection<T>> ObterPorIdsAsync<T>(ICollection<int> ids) where T : Entidade
        {
            var result = await _dataContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
            return result;
        }

        public async Task<T?> ObterPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade
        {
            var result = await _dataContext.Set<T>().FirstOrDefaultAsync(predicate);
            return result;
        }

        public async Task<ICollection<T>> ObterTodosPorCondicaoAsync<T>(Expression<Func<T, bool>> predicate) where T : Entidade
        {
            var result = await _dataContext.Set<T>().Where(predicate).ToListAsync();
            return result;
        }

        public async Task<int> SalvarAlteracoesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }


        public async Task<ICollection<T>> ObterTodosAsync<T>(ICollection<string> propriedadesRelacionamentos) where T : Entidade
        {
            if (propriedadesRelacionamentos == null) throw new Exception($"propriedadesRelacionamentos não pode ser Null");

            var query = _dataContext.Set<T>().AsQueryable();

            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade {typeof(T).Name}");
                query = query.Include(prop);
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<T?> ObterPorIdAsync<T>(int id, ICollection<string> propriedadesRelacionamentos) where T : Entidade
        {
            if (propriedadesRelacionamentos == null) throw new Exception($"propriedadesRelacionamentos não pode ser Null");

            var query = _dataContext.Set<T>().AsQueryable();

            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade {typeof(T).Name}");
                query = query.Include(prop);
            }

            var result = await query.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> EntidadeExisteAsync<T>(int id) where T : Entidade
        {
            var result = await _dataContext.Set<T>().AnyAsync(x => x.Id == id);

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
