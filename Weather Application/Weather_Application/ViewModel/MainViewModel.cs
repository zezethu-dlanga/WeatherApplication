using GalaSoft.MvvmLight;
using System.Windows.Input;
using Weather_Application.Interface;
using Xamarin.Forms;

namespace Weather_Application.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        IOpenWeatherAPIService _openWeatherAPIService;
        public ICommand GetCityWeatherCommand { protected set; get; }

        private string _cityText;
        string _currentDate;
        string _weatherIcon;
        string _max;
        string _min;
        string _currentLocation;
        bool _isLoading;
        bool _displayWeather;
        string _errorMsg;
        bool _displayErrorMsg;

        public string CityText
        {
            get { return _cityText; }
            set { _cityText = value;}
        }

        public string CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set { _weatherIcon = value; }
        }
        

        public string Max
        {
            get { return _max; }
            set { _max = value; } 
        }
        public string Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; }
        }

        public bool DisplayWeather
        {
            get { return _displayWeather; }
            set { _displayWeather = value; }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }

        public bool DisplayErrorMsg
        {
            get { return _displayErrorMsg; }
            set { _displayErrorMsg = value; }
        }

        public MainViewModel(IOpenWeatherAPIService openWeatherAPIService)
        {
            _openWeatherAPIService = openWeatherAPIService;
            GetCityWeatherCommand = new Command(CityWeatherAsync);
        }

        private async void CityWeatherAsync(object obj)
        {
            if (!string.IsNullOrEmpty(_cityText))
            {
                var result = await _openWeatherAPIService.GetCityWeatherAsync(_cityText);
                
                
                if (result != null)
                {

                }
                else
                {

                }
            }
        }
    }
}