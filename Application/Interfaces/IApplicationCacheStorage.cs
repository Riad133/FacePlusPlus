using System.Threading.Tasks;

namespace FacePlusPlus.Application.Interfaces
{
    public interface IApplicationCacheStorage
    {
        Task CacheDataAsync<T>(string key, T data, int minutes = 5);
        Task<T> ReadCacheDataAsync<T>(string key) where T : class;
        Task RemoveCacheAsync(string key);
    }
}