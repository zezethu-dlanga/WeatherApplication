using SQLite.Net.Attributes;
using System;

namespace Weather_Application.Model
{
    public class HistoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string City { get; set; }
        public string TempDescription { get; set; }
        public string WeatherIcon { get; set; }
        public string Temp { get; set; }
        public string MinTemp { get; set; }
        public string MaxTemp { get; set; }
        public DateTime SearchDate { get; set; }
    }
}