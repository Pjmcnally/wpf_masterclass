using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentConditions();
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SetupDesignerDisplay();
            };
        }

        private void SetupDesignerDisplay()
        {
            Query = "Test City";

            // Setting private variable directly to avoid triggering OnPropertyChanged event (and associated API
            // call). Otherwise this will exhaust API limit by making a call each time the designer is reloaded
            selectedCity = new City
            {
                LocalizedName = "Test City",
                Country = new Region
                {
                    LocalizedName = "United States",
                    ID = "US"
                },
                AdministrativeArea = new Region
                {
                    LocalizedName = "Minnesota",
                    ID = "MN"
                }
            };

            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Test Weather Text",
                Temperature = new Temperature
                {
                    Imperial = new UnitValue
                    {
                        Value = 32
                    }
                }
            };

            for (int i = 1; i <= 5; i++)
            {
                Cities.Add(SelectedCity);
            }
        }

        private async void GetCurrentConditions()
        {
            // Query = string.Empty;
            // Cities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();
            foreach (City city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
