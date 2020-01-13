using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModel.Helpers
{
    public partial class AccuWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string AutocompleteEndpoint = "locations/v1/cities/autocomplete?apiKey={0}&q={1}";
        
    }
}
