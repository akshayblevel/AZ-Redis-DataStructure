namespace AzRedisDataStructure.Hash
{
    public interface IRedisHashes
    {
        Task SetHashFieldAsync(string hashKey, string field, string value);
        Task<string> GetHashFieldAsync(string hashKey, string field);
        Task<Dictionary<string, string>> GetAllHashFieldsAsync(string hashKey);
        Task DeleteHashFieldAsync(string hashKey, string field);
    }
}
