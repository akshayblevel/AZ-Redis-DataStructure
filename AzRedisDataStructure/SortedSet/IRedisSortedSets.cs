using StackExchange.Redis;

namespace AzRedisDataStructure.SortedSet
{
    public interface IRedisSortedSets
    {
        Task ZAddAsync(string key, double score, string member);
        Task ZRemAsync(string key, string member);
        Task<SortedSetEntry[]> ZRangeAsync(string key, long start, long stop);
        Task<SortedSetEntry[]> ZRevRangeAsync(string key, long start, long stop);
    }
}
