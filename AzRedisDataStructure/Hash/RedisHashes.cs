using StackExchange.Redis;

namespace AzRedisDataStructure.Hash
{
    public class RedisHashes : IRedisHashes
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisHashes(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Set the value of a field in a hash. 
        /// </summary> 
        /// <param name="hashKey"></param> 
        /// <param name="field"></param> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public async Task SetHashFieldAsync(string hashKey, string field, string value)
        {
            await _database.HashSetAsync(hashKey, field, value);
        }

        /// <summary> 
        /// Get the value of a field in a hash. 
        /// </summary> 
        /// <param name="hashKey"></param> 
        /// <param name="field"></param> 
        /// <returns></returns> 
        public async Task<string> GetHashFieldAsync(string hashKey, string field)
        {
            return await _database.HashGetAsync(hashKey, field);
        }

        /// <summary> 
        /// Get all fields and values in a hash. 
        /// </summary> 
        /// <param name="hashKey"></param> 
        /// <returns></returns> 
        public async Task<Dictionary<string, string>> GetAllHashFieldsAsync(string hashKey)
        {
            var entries = await _database.HashGetAllAsync(hashKey);
            return entries.ToDictionary(x => (string)x.Name, x => (string)x.Value);
        }

        /// <summary> 
        /// Delete a field from a hash. 
        /// </summary> 
        /// <param name="hashKey"></param> 
        /// <param name="field"></param> 
        /// <returns></returns> 
        public async Task DeleteHashFieldAsync(string hashKey, string field)
        {
            await _database.HashDeleteAsync(hashKey, field);
        }
    }

}
