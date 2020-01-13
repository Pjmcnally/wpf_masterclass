using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public partial class AccuWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string AutocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CurrentConditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string query)
        {
            string url = BaseUrl + string.Format(AutocompleteEndpoint, ApiKey, query);
            var response = await App.client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<City>>(json); ;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            string url = BaseUrl + string.Format(CurrentConditionsEndpoint, ApiKey, cityKey);
            var response = await App.client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            return (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
        }
    }
}
