using Microsoft.Extensions.Caching.Memory;
using System;

namespace Vehicle.Core.Helpers
{
    public static class CacheHelpers
    {
        private static readonly Lazy<MemoryCache> lazyMemoryCache = new(() =>
            {
                return new MemoryCache(new MemoryCacheOptions());
            }
        );
        private static MemoryCache MemoryCacheInstance => lazyMemoryCache.Value;

        public static bool IsCached(string cacheKey)
        {
            return MemoryCacheInstance.TryGetValue(cacheKey, out _);
        }

        public static T GetCached<T>(string cacheKey)
        {
            MemoryCacheInstance.TryGetValue(cacheKey, out T result);

            return result;
        }

        public static void SetTokenCache<T>(string cacheKey, T toCache)
        {
            SetCache(cacheKey, toCache, new TimeSpan(0, 15, 0));
        }

        public static void SetCache<T>(string cacheKey, T toCache, TimeSpan timeSpan)
        {
            MemoryCacheInstance.Set(cacheKey, toCache, timeSpan);
        }

        public static void RemoveCache(string cacheKey)
        {
            MemoryCacheInstance.Remove(cacheKey);
        }
    }
}
