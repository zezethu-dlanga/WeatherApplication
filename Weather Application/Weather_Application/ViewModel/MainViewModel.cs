using GalaSoft.MvvmLight;
using Plugin.Connectivity;
using System;
using System.Windows.Input;
using Weather_Application.Interface;
using Xamarin.Forms;

namespace Weather_Application.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        INavigationService _navigationService;
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
        bool _displayWelcomeMsg;

        public string CityText
        {
            get { return _cityText; }
            set { _cityText = value; RaisePropertyChanged(); }
        }

        public string CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; RaisePropertyChanged(); }
        }

        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set { _weatherIcon = value; RaisePropertyChanged(); }
        }
        

        public string Max
        {
            get { return _max; }
            set { _max = value; RaisePropertyChanged(); } 
        }
        public string Min
        {
            get { return _min; }
            set {
                _min = value;
                RaisePropertyChanged();
            }
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set {
                _currentLocation = value;
                RaisePropertyChanged();
            }

        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        public bool DisplayWeather
        {
            get { return _displayWeather; }
            set { _displayWeather = value; RaisePropertyChanged(); }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; RaisePropertyChanged(); }
        }

        public bool DisplayErrorMsg
        {
            get { return _displayErrorMsg; }
            set { _displayErrorMsg = value; RaisePropertyChanged(); }
        }

        public bool DisplayWelcomeMsg
        {
            get { return _displayWelcomeMsg; }
            set { _displayWelcomeMsg = value; RaisePropertyChanged(); }
        }

        public MainViewModel(INavigationService navigationService, IOpenWeatherAPIService openWeatherAPIService)
        {
            _navigationService = navigationService;
            _openWeatherAPIService = openWeatherAPIService;
            GetCityWeatherCommand = new Command(CityWeatherAsync);
            _displayWelcomeMsg = true;
        }

        private async void CityWeatherAsync(object obj)
        {
            DisplayWelcomeMsg = false;
            DisplayErrorMsg = false;
            IsLoading = true;
            DateTime currentDay = DateTime.Today;

            if (!string.IsNullOrEmpty(_cityText))
            {
                try
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        var apiResuslt = await _openWeatherAPIService.GetCityWeatherAsync(_cityText);

                    
                        if (apiResuslt != null)
                        {
                            CurrentDate = currentDay.ToString("D");


                            foreach (var icon in apiResuslt.weather)
                            {
                                WeatherIcon = "http://openweathermap.org/img/w/" + icon.icon + ".png";
                            }

                            Max = "max " + apiResuslt.main.temp_max;
                            Min = "min " + apiResuslt.main.temp_min;

                            CurrentLocation = apiResuslt.name;

                            IsLoading = false;
                            DisplayErrorMsg = false;
                            DisplayWeather = true;
                        }
                        else
                        {
                            IsLoading = false;
                            DisplayWeather = false;
                            DisplayErrorMsg = true;
                            ErrorMsg = "The city you looking for cannot be found.";
                        }
                    }
                    else
                    {
                        IsLoading = false;
                        DisplayWeather = false;
                        DisplayErrorMsg = true;
                        ErrorMsg = "Unable to connect. Please check your network connection and try again.";
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    IsLoading = false;
                    DisplayWeather = false;
                    DisplayErrorMsg = true;
                    ErrorMsg = "The city you looking for cannot be found.";
                }
            }
        }
    }
}