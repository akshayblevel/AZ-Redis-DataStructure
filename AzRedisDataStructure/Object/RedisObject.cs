using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzRedisDataStructure.Object
{
    public class RedisObject : IRedisObject
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisObject(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var json = JsonConvert.SerializeObject(value);
            await _database.StringSetAsync(key, json, expiry);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var json = await _database.StringGetAsync(key);
            return json.IsNullOrEmpty ? default : JsonConvert.DeserializeObject<T>(json);
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }

}
