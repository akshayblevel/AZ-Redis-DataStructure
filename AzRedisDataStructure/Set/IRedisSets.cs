using StackExchange.Redis;

namespace AzRedisDataStructure.Set
{
    public interface IRedisSets
    {
        Task SAddAsync(string key, params string[] members);
        Task SRemAsync(string key, params string[] members);
        Task<bool> SIsMemberAsync(string key, string member);
        Task<RedisValue[]> SMembersAsync(string key);
    }
}
