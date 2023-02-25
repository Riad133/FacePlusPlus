using System;
using System.Threading.Tasks;
using FacePlusPlus.Application.Interfaces;
using FacePlusPlus.Utiles;
using Microsoft.Extensions.Caching.Distributed;

namespace FacePlusPlus.Infrastructure
{
    public class DistributedCacheStorage : IApplicationCacheStorage
    {
        
        private readonly IDistributedCache _cache;

        public DistributedCacheStorage(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task CacheDataAsync<T>(string key, T data, int minutes)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(minutes));
            await _cache.SaveObjectAsync(key, data, options);
        }

        public async Task<T> ReadCacheDataAsync<T>(string key) where T : class
        {
            var data = await _cache.GetObjectAsync<T>(key);
            return data;
        }
    }
}