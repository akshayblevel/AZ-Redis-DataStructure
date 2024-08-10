using StackExchange.Redis;

namespace AzRedisDataStructure.List
{
    public interface IRedisLists
    {
        Task LPushAsync(string key, string value);
        Task RPushAsync(string key, string value);
        Task<string> LPopAsync(string key);
        Task<string> RPopAsync(string key);
        Task<RedisValue[]> LRangeAsync(string key, long start, long stop);
    }
}
