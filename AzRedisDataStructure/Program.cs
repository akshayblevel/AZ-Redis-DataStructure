using AzRedisDataStructure.HyperLogLog;
using AzRedisDataStructure.List;
using AzRedisDataStructure.Object;
using AzRedisDataStructure.Set;
using AzRedisDataStructure.SortedSet;
using AzRedisDataStructure.String;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redisConnectionString = builder.Configuration.GetSection("Redis:ConnectionString").Value;
var multiplexer = ConnectionMultiplexer.Connect(redisConnectionString);

builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddSingleton<IRedisObject, RedisObject>();
builder.Services.AddSingleton<IRedisString, RedisString>();
builder.Services.AddSingleton<IRedisLists, RedisLists>();
builder.Services.AddSingleton<IRedisSets, RedisSets>();
builder.Services.AddSingleton<IRedisSortedSets, RedisSortedSets>();
builder.Services.AddSingleton<IRedisHyperLogLog, RedisHyperLogLog>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
