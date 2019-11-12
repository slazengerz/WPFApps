using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuWeatherApp.Model
{
    class GetWeather
    {
        public class Headline
        {
            public DateTime EffectiveDate { get; set; }
            public string Text { get; set; }
            public string Category { get; set; }
        }

        public class Minimum
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Maximum
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Temperature
        {
            public Minimum Minimum { get; set; }
            public Maximum Maximum { get; set; }
        }

        public class Day
        {
            public int Icon { get; set; }
            public string IconPhrase { get; set; }
            public bool HasPrecipitation { get; set; }
            public string PrecipitationType { get; set; }
            public string PrecipitationIntensity { get; set; }
        }

        public class DailyForecast
        {
            public DateTime Date { get; set; }
            public Temperature Temperature { get; set; }
            public Day Day { get; set; }
        }

        public class AccuWeatherDetails
        {
            public Headline Headline { get; set; }
            public List<DailyForecast> DailyForecasts { get; set; }
        }
    }
}
