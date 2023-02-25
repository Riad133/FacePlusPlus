using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FacePlusPlus.Utiles
{
    public static class CacheUtils
    {
        public static async Task<T> GetObjectAsync<T>(this IDistributedCache cache, string key) where T : class
        {
            var json =
                await cache.GetAsync(key);

            if (json == null)
            {
                return null;
            }

            var data = DataCompressor.Decompress(Encoding.UTF8.GetString(json));

            var storedObject = JsonConvert.DeserializeObject<T>(data, JsonUtils.DefaultJsonSerializerSettings());

            return storedObject;
        }

        public static T GetObject<T>(this IDistributedCache cache, string key) where T : class
        {
            var json =
                cache.Get(key);

            if (json == null)
            {
                return null;
            }

            var data = DataCompressor.Decompress(Encoding.UTF8.GetString(json));

            var storedObject = JsonConvert.DeserializeObject<T>(data, JsonUtils.DefaultJsonSerializerSettings());

            return storedObject;
        }

        public static async Task SaveObjectAsync<T>(this IDistributedCache cache, string key, T item,
            DistributedCacheEntryOptions options)
        {
            var data = DataCompressor.Compress(JsonConvert.SerializeObject(item,
                JsonUtils.DefaultJsonSerializerSettings()));
            await cache.SetStringAsync(key,
                data, options);
        }

        public static async void SaveObject<T>(this IDistributedCache cache, string key, T item,
            DistributedCacheEntryOptions options)
        {
            var data = DataCompressor.Compress(JsonConvert.SerializeObject(item,
                JsonUtils.DefaultJsonSerializerSettings()));
            await cache.SetStringAsync(key,
                data, options);
        }
    }
}