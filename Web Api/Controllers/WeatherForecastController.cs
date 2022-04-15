using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracin g", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<WeatherForecast> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var key = "43becd2fb33d465886e80749221504";
                var uri = "https://api.weatherapi.com/v1/forecast.xml";
                var q = "London";
                var days = "1";
                var aqi = "no";
                var alerts = "no";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = await client.GetAsync($"?key={key}&q={q}&days={days}&aqi={aqi}&alerts={alerts}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var xmlResponse = XElement.Parse(responseBody);
                    var temperature = xmlResponse.Descendants().First(node => node.Name == "avgtemp_c").Value;
                    var condition = xmlResponse.Descendants().FirstOrDefault(xmlResponse => xmlResponse.Name == "condition");
                    var weather = condition.Descendants().First(node => node.Name == "text").Value;

                    return new WeatherForecast
                    {
                        Temperature = temperature,
                        Weather = temperature
                    };
                }
                return null;
            }
        }
    }
}