using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Weather_Application.Interfaces;
using Weather_Application.Model;
using Xamarin.Forms;

namespace Weather_Application.Service
{
    public class LocalDataStore : IDataStore
    {
        private SQLiteConnection _sqlconnection;

        public LocalDataStore()
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<HistoryItem>();
        }
        
        public IList<HistoryItem> GetAllWeatherHistory()
        {
            return (from t in _sqlconnection.Table<HistoryItem>() select t).ToList();
        }
        
        public HistoryItem GetWeatherHistory(int id)
        {
            return _sqlconnection.Table<HistoryItem>().FirstOrDefault(t => t.Id == id);
        }

        public void DeleteWeatherHistory(int id)
        {
            _sqlconnection.Delete<HistoryItem>(id);
        }

        public void DeleteAllWeatherHistory()
        {
            _sqlconnection.DeleteAll<HistoryItem>();
        }

        public void AddWeatherHistory(HistoryItem weatherHistory)
        {
            _sqlconnection.Insert(weatherHistory);
        }
    }
}
