﻿using Domain.Interfaces.Caching.Interfaces;
using Domain.Interfaces.Caching.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;



namespace Infra.Caching.Repositories
{


    public class CommonCachingRepository : ICommonCachingRepository
    {
        private readonly IDistributedCache _cache;

        public CommonCachingRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key) where T : ICommonCaching
        {
            var resultString = await _cache.GetStringAsync(key.ToString());

            if (resultString == null)
            {
                return default;
            }

            var resultModel = JsonConvert.DeserializeObject<T>(resultString);

            return resultModel;
        }

        public async Task<bool> SetAsync<T>(T value, TimeSpan expiration) where T : ICommonCaching
        {
            var stringValue = JsonConvert.SerializeObject(value);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            await _cache.SetStringAsync(value.ObterKey(), stringValue, options);

            return true;
        }

        public async Task<bool> RemoveAsync<T>(T value) where T : ICommonCaching
        {
            await _cache.RemoveAsync(value.ObterKey());

            return true;
        }

    }

}
