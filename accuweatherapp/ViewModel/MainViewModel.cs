using AccuWeatherApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AccuWeatherApp.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {
            LocationResults = new ObservableCollection<GetLocations.Location>();
            CurrentConditions = new GetCurrentConditions.CurrentConditions();
        }
        private string query;
        private GetLocations.Location selecteditem;
        public ObservableCollection<GetLocations.Location> LocationResults { get; set; }
        public GetCurrentConditions.CurrentConditions CurrentConditions { get; set; }

        public GetLocations.Location SelectedItem
        {
            get { return selecteditem; }
            set
            {
                selecteditem = value;
                //here call the get current conditions API
                callAPItoGetCurrentConditions(selecteditem.Key);      
            }
        }

        private async void callAPItoGetCurrentConditions(string selecteditem)
        {
            List<GetCurrentConditions.CurrentConditions> conditions = new List<GetCurrentConditions.CurrentConditions>();
            conditions = await CallAPI.getCurrentWeather(selecteditem);
            Console.WriteLine($"count of records retured is {conditions.Count}");
            foreach(var condition in conditions)
            {
                CurrentConditions.WeatherText = condition.WeatherText;
                CurrentConditions.Temperature.Metric.Value = condition.Temperature.Metric.Value;
                CurrentConditions.Temperature.Metric.Unit = condition.Temperature.Metric.Unit;
                Console.WriteLine($"Current temp is {CurrentConditions.WeatherText}");
            }
        }

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                System.Console.WriteLine($"Value typed is {query}");
                if(query.Length>=4)
                {
                    Console.WriteLine($"before calling{query}");
                    callAPItoGetLocations(query);  
                }
            }
        }

        private async void callAPItoGetLocations(string query)
        {
           var result =await CallAPI.getLocResult(query);
           System.Console.WriteLine("Result count is");
            foreach (var loc in result)
            {
                LocationResults.Add(loc);
            }
        }
    }
}
