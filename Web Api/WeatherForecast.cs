namespace Web_Api
{
    public class WeatherForecastModel
    {
        public string Temperature { get; set; }
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
        public Day Day{ get; set; }
    }
    public class Day
    {
        public Condition Condition { get; set; }
        public string AvgTemp_C { get; set; }
    }
    public class Condition
    {
        public string Text { get; set; }

    }
}