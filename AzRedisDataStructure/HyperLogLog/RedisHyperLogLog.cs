using StackExchange.Redis;

namespace AzRedisDataStructure.HyperLogLog
{
    public class RedisHyperLogLog : IRedisHyperLogLog
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisHyperLogLog(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Add elements to a HyperLogLog. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="elements"></param> 
        /// <returns></returns> 
        public async Task PFAddAsync(string key, params string[] elements)
        {
            await _database.HyperLogLogAddAsync(key, elements.Select(e => (RedisValue)e).ToArray());
        }

        /// <summary> 
        /// Get the approximated cardinality of the HyperLogLog. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public async Task<long> PFCountAsync(string key)
        {
            return await _database.HyperLogLogLengthAsync(key);
        }
    }

}
