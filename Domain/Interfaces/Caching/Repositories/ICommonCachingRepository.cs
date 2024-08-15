using Domain.Interfaces.Caching.Interfaces;

namespace Domain.Interfaces.Caching.Repositories
{
    public interface ICommonCachingRepository
    {

        Task<T?> GetAsync<T>(string key) where T : ICommonCaching;
        Task<bool> SetAsync<T>(T value, TimeSpan expiration) where T : ICommonCaching;
        Task<bool> RemoveAsync<T>(T value) where T : ICommonCaching;

    }
}
