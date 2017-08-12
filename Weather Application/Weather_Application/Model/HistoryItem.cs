using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Application.Model
{
    public class HistoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TempDescription { get; set; }
        public string WeatherIcon { get; set; }
        public double Temp { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
