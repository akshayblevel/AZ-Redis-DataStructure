using StackExchange.Redis;

namespace AzRedisDataStructure.Set
{
    public class RedisSets : IRedisSets
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisSets(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary> 
        /// Add one or more members to a set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="members"></param> 
        /// <returns></returns> 
        public async Task SAddAsync(string key, params string[] members)
        {
            await _database.SetAddAsync(key, members.Select(m => (RedisValue)m).ToArray());
        }

        /// <summary> 
        /// Remove one or more members from a set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="members"></param> 
        /// <returns></returns> 
        public async Task SRemAsync(string key, params string[] members)
        {
            await _database.SetRemoveAsync(key, members.Select(m => (RedisValue)m).ToArray());
        }

        /// <summary> 
        /// Determine if a given value is a member of a set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <param name="member"></param> 
        /// <returns></returns> 
        public async Task<bool> SIsMemberAsync(string key, string member)
        {
            return await _database.SetContainsAsync(key, member);
        }

        /// <summary> 
        /// Get all the members in a set. 
        /// </summary> 
        /// <param name="key"></param> 
        /// <returns></returns> 
        public async Task<RedisValue[]> SMembersAsync(string key)
        {
            return await _database.SetMembersAsync(key);
        }
    }

}
