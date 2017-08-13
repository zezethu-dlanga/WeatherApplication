using GalaSoft.MvvmLight;
using Plugin.Connectivity;
using System;
using System.Windows.Input;
using Weather_Application.Interfaces;
using Weather_Application.Model;
using Xamarin.Forms;

namespace Weather_Application.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IOpenWeatherAPIService _openWeatherAPIService;
        IDataStore _dataStore;
        public ICommand GetCityWeatherCommand { protected set; get; }
        public ICommand HistoryCommand { protected set; get; }

        string _cityText, _currentDate, _weatherIcon, _currentLocation, _temp, _max, _min, _errorMsg, _currentDescription;
        bool _isLoading, _displayWeather, _displayErrorMsg, _displayWelcomeMsg;

        public string CurrentDescription
        {
            get { return _currentDescription; }
            set { _currentDescription = value; RaisePropertyChanged(); }
        }

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

        public string Temp
        {
            get { return _temp; }
            set { _temp = value; RaisePropertyChanged(); }
        }

        public string Max
        {
            get { return _max; }
            set { _max = value; RaisePropertyChanged(); } 
        }

        public string Min
        {
            get { return _min; }
            set { _min = value; RaisePropertyChanged(); }
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; RaisePropertyChanged(); }
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

        public MainViewModel(INavigationService navigationService, IOpenWeatherAPIService openWeatherAPIService, IDataStore dataStore)
        {
            _navigationService = navigationService;
            _openWeatherAPIService = openWeatherAPIService;
            _dataStore = dataStore;

            GetCityWeatherCommand = new Command(CityWeatherAsync);
            HistoryCommand = new Command(History);
            _displayWelcomeMsg = true;
        }

        private async void CityWeatherAsync()
        {
            DisplayWelcomeMsg = false;
            DisplayErrorMsg = false;
            DisplayWeather = false;
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

                            Temp = KelvinToCelsius(apiResuslt.main.temp).ToString();

                            foreach (var icon in apiResuslt.weather)
                            {
                                CurrentDescription = icon.description;
                                WeatherIcon = "http://openweathermap.org/img/w/" + icon.icon + ".png";
                            }

                            Max = "max " + KelvinToCelsius(apiResuslt.main.temp_max);
                            Min = "min " + KelvinToCelsius(apiResuslt.main.temp_min);

                            CurrentLocation = apiResuslt.name + ", " + apiResuslt.sys.country;

                            SaveToHistoryData();

                            IsLoading = false;
                            DisplayErrorMsg = false;
                            DisplayWelcomeMsg = false;
                            DisplayWeather = true;
                        }
                        else
                        {
                            DisplayErrorMessage("The city you looking for cannot be found.");
                        }
                    }
                    else
                    {
                        DisplayErrorMessage("Unable to connect. Please check your network connection and try again.");
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    DisplayErrorMessage("The city you looking for cannot be found.");
                }
            }
            else
            {
                DisplayErrorMessage("Please type in the name of the city.");
            }
        }

        public void History()
        {
            _navigationService.NavigateTo(Enum.AppPages.History);
        }

        private void DisplayErrorMessage(string errorMsg)
        {
            IsLoading = false;
            DisplayWeather = false;
            DisplayWelcomeMsg = false;
            DisplayErrorMsg = true;
            ErrorMsg = errorMsg;
        }

        private double KelvinToCelsius(double kelvin)
        {
            var results = Math.Round(kelvin - 273.15);
            return results;
        }

        private void SaveToHistoryData()
        {
            DateTime currentDay = DateTime.Now;

            HistoryItem item = new HistoryItem()
            {
                SearchDate = currentDay,
                City = CityText,
                MaxTemp = Max,
                MinTemp = Min,
                Temp = Temp,
                TempDescription = CurrentDescription,
                WeatherIcon = WeatherIcon
            };

            _dataStore.AddWeatherHistory(item);
        }
    }
}