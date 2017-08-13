using System;
using Weather_Application.Model;

namespace Weather_Application.ViewModel
{
    public class HistoryRowViewModel
    {
        private int _id;
        private string _city, _tempDescription, _weatherIcon, _temp, _minTemp, _maxTemp, _searchDate;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string City {
            get { return _city; }
            set { _city = value; }
        }

        public string TempDescription
        {
            get { return _tempDescription; }
            set { _tempDescription = value; }
        }

        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set { _weatherIcon = value; }
        }

        public string Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public string MinTemp
        {
            get { return _minTemp; }
            set { _minTemp = value; }
        }

        public string MaxTemp
        {
            get { return _maxTemp; }
            set { _maxTemp = value; }
        }
        public string SearchDate
        {
            get { return _searchDate; }
            set { _searchDate = value; }
        }

        public HistoryItem HistoryDataItem { get; set; }
    }
}