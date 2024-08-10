using StackExchange.Redis;

namespace AzRedisDataStructure.List
{
    public class RedisLists : IRedisLists
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisLists(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Prepend one or multiple values to a list. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public async Task LPushAsync(string key, string value)
        {
            await _database.ListLeftPushAsync(key, value);
        }

        /// <summary> 
        /// Append one or multiple values to a list. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public async Task RPushAsync(string key, string value)
        {
            await _database.ListRightPushAsync(key, value);
        }

        /// <summary> 
        /// Remove and get the first element in a list.  
        /// </summary> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public async Task<string> LPopAsync(string key)
        {
            return await _database.ListLeftPopAsync(key);
        }

        /// <summary> 
        /// Remove and get the last element in a list. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public async Task<string> RPopAsync(string key)
        {
            return await _database.ListRightPopAsync(key);
        }

        /// <summary> 
        /// Get a range of elements from a list. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="start"></param> 
        /// <param name="stop"></param> 
        /// <returns></returns> 
        public async Task<RedisValue[]> LRangeAsync(string key, long start, long stop)
        {
            return await _database.ListRangeAsync(key, start, stop);
        }
    }
}
