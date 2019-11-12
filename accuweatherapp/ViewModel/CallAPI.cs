using AccuWeatherApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AccuWeatherApp.ViewModel
{
    class CallAPI
    {
        private const string API_KEY = "WGysXdajiJBk2n77W7rN0tg4X5edzPRn";
        private const string URL_LOC = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        private const string URL_WEATHER = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/{0}?apikey={1}&metric=true";
        private const string URL_CURRENT = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<GetLocations.Location>> getLocResult(string query)
        {
            Console.WriteLine("entered task");
            List<GetLocations.Location> retunval = new List<GetLocations.Location>();
            using (HttpClient client=new HttpClient())
            {
                Console.WriteLine("entered task 1 with val "+query);
                //var response = await client.GetAsync(string.Format(URL_LOC, API_KEY, query));
                //string resultJson = await response.Content.ReadAsStringAsync();
                string resultJson = "[{\"Version\":1,\"Key\":\"22889\",\"Type\":\"City\",\"Rank\":11,\"LocalizedName\":\"Sydney\",\"Country\":{\"ID\":\"AU\",\"LocalizedName\":\"Australia\"},\"AdministrativeArea\":{\"ID\":\"NSW\",\"LocalizedName\":\"New South Wales\"}},{\"Version\":1,\"Key\":\"3496594\",\"Type\":\"City\",\"Rank\":65,\"LocalizedName\":\"Sydney CBD\",\"Country\":{\"ID\":\"AU\",\"LocalizedName\":\"Australia\"},\"AdministrativeArea\":{\"ID\":\"NSW\",\"LocalizedName\":\"New South Wales\"}},{\"Version\":1,\"Key\":\"54678\",\"Type\":\"City\",\"Rank\":65,\"LocalizedName\":\"Sydney\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"NS\",\"LocalizedName\":\"Nova Scotia\"}},{\"Version\":1,\"Key\":\"54816\",\"Type\":\"City\",\"Rank\":75,\"LocalizedName\":\"Sydney Mines\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"NS\",\"LocalizedName\":\"Nova Scotia\"}},{\"Version\":1,\"Key\":\"3496580\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney Olympic Park\",\"Country\":{\"ID\":\"AU\",\"LocalizedName\":\"Australia\"},\"AdministrativeArea\":{\"ID\":\"NSW\",\"LocalizedName\":\"New South Wales\"}},{\"Version\":1,\"Key\":\"3494337\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney Island\",\"Country\":{\"ID\":\"AU\",\"LocalizedName\":\"Australia\"},\"AdministrativeArea\":{\"ID\":\"QLD\",\"LocalizedName\":\"Queensland\"}},{\"Version\":1,\"Key\":\"3556245\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney Island\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"BC\",\"LocalizedName\":\"British Columbia\"}},{\"Version\":1,\"Key\":\"3392437\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney Cove\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"NL\",\"LocalizedName\":\"Newfoundland\"}},{\"Version\":1,\"Key\":\"2289580\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney Forks\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"NS\",\"LocalizedName\":\"Nova Scotia\"}},{\"Version\":1,\"Key\":\"1365421\",\"Type\":\"City\",\"Rank\":85,\"LocalizedName\":\"Sydney River\",\"Country\":{\"ID\":\"CA\",\"LocalizedName\":\"Canada\"},\"AdministrativeArea\":{\"ID\":\"NS\",\"LocalizedName\":\"Nova Scotia\"}}]";
                Console.WriteLine($"resultJson is {resultJson}");
                retunval = JsonConvert.DeserializeObject<List<GetLocations.Location>>(resultJson);
            }
            return  retunval;
        }

        public static async Task<List<GetCurrentConditions.CurrentConditions>> getCurrentWeather(string lockey)
        {
            List<GetCurrentConditions.CurrentConditions> result = new List<GetCurrentConditions.CurrentConditions>();
            using (HttpClient client = new HttpClient())
            {
                //var response = await client.GetAsync(string.Format(URL_CURRENT, lockey, API_KEY));
                //string jsonresponse = await response.Content.ReadAsStringAsync();
                string jsonresponse = "[{\"LocalObservationDateTime\":\"2019-10-01T05:25:00+10:00\",\"EpochTime\":1569871500,\"WeatherText\":\"Partly cloudy\",\"WeatherIcon\":35,\"HasPrecipitation\":false,\"PrecipitationType\":null,\"IsDayTime\":false,\"Temperature\":{\"Metric\":{\"Value\":12.5,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":54.0,\"Unit\":\"F\",\"UnitType\":18}},\"MobileLink\":\"http://m.accuweather.com/en/au/sydney-cbd/3496594/current-weather/3496594?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/au/sydney-cbd/3496594/current-weather/3496594?lang=en-us\"}]";
                Console.WriteLine($"jsonresponse {jsonresponse}");
                result = JsonConvert.DeserializeObject<List<GetCurrentConditions.CurrentConditions>>(jsonresponse);
                return result;
            }
        }
        public static async void getWeatherForecast(string lockey)
        {
            using(HttpClient client=new HttpClient())
            {
                var response = await client.GetAsync(string.Format(URL_WEATHER, lockey, API_KEY));
                string jsonresponse =await response.Content.ReadAsStringAsync();
            }
        }
    }

}
