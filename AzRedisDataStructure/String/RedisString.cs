using StackExchange.Redis;

namespace AzRedisDataStructure.String
{
    public class RedisString : IRedisString
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisString(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Store a string value for a key. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public async Task SetStringAsync(string key, string value)
        {
            await _database.StringSetAsync(key, value);
        }

        /// <summary> 
        /// Retrieve a string value by key. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public async Task<string> GetStringAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }

        /// <summary> 
        /// Increase the integer value of a key by a given amount.  
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="increment"></param> 
        /// <returns></returns> 
        public async Task IncrementStringAsync(string key, long increment)
        {
            await _database.StringIncrementAsync(key, increment);
        }

        /// <summary> 
        /// Append a value to an existing string key. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public async Task AppendStringAsync(string key, string value)
        {
            await _database.StringAppendAsync(key, value);
        }
    }

}
