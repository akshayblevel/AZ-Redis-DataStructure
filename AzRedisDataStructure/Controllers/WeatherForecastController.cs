using AzRedisDataStructure.Object;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AzRedisDataStructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IRedisObject redisObject) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            var forecast = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };


            // Set forecast object to redish

            await redisObject.SetAsync("forecast:1", forecast);

            // Get forecast object from redish
            var cacheForecast = await redisObject.GetAsync<WeatherForecast>("forecast:1");
            Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(cacheForecast));


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
