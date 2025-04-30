using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("forecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("forecastModel", Name = "GetWeatherForecastModel")]
        public WeatherForecast GetWeatherForecastModel()
        {
            var weatherForecastModel = typeof(WeatherForecast);

            var constructors = weatherForecastModel.GetConstructors();
            var defaultConstructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);

            var obj = defaultConstructor.Invoke(null);

            var properties = weatherForecastModel.GetProperties();

            foreach (var property in properties)
            {
                if (_weatherForecastValues.TryGetValue(property.Name, out var value))
                {
                    if(property.PropertyType.Name == "DateOnly")
                    {
                        var specifiedValue = DateOnly.Parse(value);
                        property.SetValue(obj, specifiedValue);
                    }
                    else
                    {
                        var specifiedValue = Convert.ChangeType(value, property.PropertyType);
                        property.SetValue(obj, specifiedValue);
                    }                        
                }
            }
            return (WeatherForecast)obj;
        }

        private Dictionary<string, string> _weatherForecastValues = new Dictionary<string, string>
        {
            { "Date", DateOnly.FromDateTime(DateTime.Now).ToString() },
            { "TemperatureC", "25" },
            { "Summary", Guid.NewGuid().ToString() }
        };
    }
}
