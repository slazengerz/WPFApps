using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuWeatherApp.Model
{
    class GetCurrentConditions
    {
        public class Metric:INotifyPropertyChanged
        {
            private double val;
            private string unit;
            public event PropertyChangedEventHandler PropertyChanged;
            public double Value
            {
                get { return val; }
                set
                {  
                    val = value;
                    OnPropertyChanged("Value");
                }
            }
            public string Unit {
                get { return unit; }
                set
                {
                    unit = value;
                    OnPropertyChanged("Unit");
                }
            }
            public int UnitType { get; set; }
            private void OnPropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }

        public class Imperial:INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private double val;
            public double Value
            {
                get { return val; }
                set
                {
                    val = value;
                    OnPropertyChanged("Value");
                }
            }
            public string Unit { get; set; }
            public int UnitType { get; set; }
            private void OnPropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }

        public class Temperature:INotifyPropertyChanged
        {
            private Metric metric;
            public Imperial Imperial { get; set; }
            public Temperature()
            {
                metric = new Metric();
            }
           
            public event PropertyChangedEventHandler PropertyChanged;
            public Metric Metric
            {
                get { return metric; }
                set
                {
                    metric = value;
                    OnPropertyChanged("Metric");
                }
            }
            
            private void OnPropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }

        public class CurrentConditions : INotifyPropertyChanged
        {
            private Temperature temperature;
            private string weathertext;

            public event PropertyChangedEventHandler PropertyChanged;

            public CurrentConditions()
            {
                temperature = new Temperature();
            }
            public DateTime LocalObservationDateTime { get; set; }
            public string WeatherText {
                get { return weathertext; }
                set
                {
                    weathertext = value;
                    OnProrpertyChanged("WeatherText");
                }
            }  
            public Temperature Temperature
            {
                get { return temperature;}
                set
                {
                    temperature = value;
                    OnProrpertyChanged("Temperature");
                }
            }
            private void OnProrpertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }
    }
}
