namespace AzRedisDataStructure.String
{
    public interface IRedisString
    {
        Task SetStringAsync(string key, string value);
        Task<string> GetStringAsync(string key);
        Task IncrementStringAsync(string key, long increment);
        Task AppendStringAsync(string key, string value);
    }

}
