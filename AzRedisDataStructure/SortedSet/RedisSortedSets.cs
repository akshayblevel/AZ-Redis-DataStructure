using StackExchange.Redis;

namespace AzRedisDataStructure.SortedSet
{
    public class RedisSortedSets : IRedisSortedSets
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisSortedSets(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Add a member with a score to a sorted set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="score"></param> 
        /// <param name="member"></param> 
        /// <returns></returns> 
        public async Task ZAddAsync(string key, double score, string member)
        {
            await _database.SortedSetAddAsync(key, member, score);
        }

        /// <summary> 
        /// Remove a member from a sorted set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="member"></param> 
        /// <returns></returns> 
        public async Task ZRemAsync(string key, string member)
        {
            await _database.SortedSetRemoveAsync(key, member);
        }

        /// <summary> 
        /// Get a range of members from a sorted set, ordered from lowest to highest score. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="start"></param> 
        /// <param name="stop"></param> 
        /// <returns></returns> 
        public async Task<SortedSetEntry[]> ZRangeAsync(string key, long start, long stop)
        {
            return await _database.SortedSetRangeByRankWithScoresAsync(key, start, stop);
        }

        /// <summary> 
        /// Get a range of members from a sorted set, ordered from highest to lowest score. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="start"></param> 
        /// <param name="stop"></param> 
        /// <returns></returns> 
        public async Task<SortedSetEntry[]> ZRevRangeAsync(string key, long start, long stop)
        {
            return await _database.SortedSetRangeByRankWithScoresAsync(key, start, stop, Order.Descending);
        }
    }

}
