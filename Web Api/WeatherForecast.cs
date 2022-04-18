namespace Web_Api
{
    public class WeatherForecastModel
    {
        public float Temperature { get; set; }
        public string Weather { get; set; }

    }

    public class WeatherForecast
    {
        public ForeCast ForeCast { get; set; }

    }
    public class ForeCast
    {
        public List<ForeCastDay> ForeCastDay { get; set; }

    }
    public class ForeCastDay
    {
        public Day Day { get; set; }
    }
    public class Day
    {
        public Condition Condition { get; set; }
        public float AvgTemp_C { get; set; }
    }
    public class Condition
    {
        public string Text { get; set; }

    }
    /// <summary>Input Data</summary>
    public class InputModel
    {
        /// <summary>Location of Forecast</summary>
        public string Q { get; set; }
        /// <summary>Days of Forecast</summary>
        public string Days { get; set; }
        /// <summary>Aqi</summary>
        public string Aqi { get; set; }
        /// <summary>Alert</summary>
        public string Alerts { get; set; }
    }
}