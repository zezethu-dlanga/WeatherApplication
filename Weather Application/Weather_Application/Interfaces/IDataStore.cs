using System.Collections.Generic;
using Weather_Application.Model;

namespace Weather_Application.Interfaces
{
    public interface IDataStore
    {
        IList<HistoryItem> GetAllWeatherHistory();
        HistoryItem GetWeatherHistory(int id);
        void DeleteWeatherHistory(int id);
        void DeleteAllWeatherHistory();
        void AddWeatherHistory(HistoryItem weatherHistory);
    }
}