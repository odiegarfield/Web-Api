using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<WeatherForecastModel> GetAsync(string q, string days, string aqi, string alerts)
        {
            using (var client = new HttpClient())
            {
                var key = _config["Key"];
                var uri = $"{_config["Url"]}v1/forecast.json";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = await client.GetAsync($"?key={key}&q={q}&days={days}&aqi={aqi}&alerts={alerts}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonBody = await response.Content.ReadAsStringAsync();
                    var body = JsonConvert.DeserializeObject<WeatherForecast>(jsonBody);
                    var temperature = body.ForeCast.ForeCastDay.FirstOrDefault().Day.AvgTemp_C;
                    var weather = body.ForeCast.ForeCastDay.FirstOrDefault().Day.Condition.Text;
                    return new WeatherForecastModel
                    {
                        Temperature = temperature,
                        Weather = weather
                    };
                }
                return null;
            }
        }
    }
}