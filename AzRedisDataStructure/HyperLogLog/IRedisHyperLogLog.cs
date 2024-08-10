namespace AzRedisDataStructure.HyperLogLog
{
    public interface IRedisHyperLogLog
    {
        Task PFAddAsync(string key, params string[] elements);
        Task<long> PFCountAsync(string key);
    }
}
