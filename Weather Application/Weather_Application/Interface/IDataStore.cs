using System.Collections.Generic;
using System.Threading.Tasks;
using Weather_Application.Model;

namespace Weather_Application.Interface
{
    public interface IDataStore
    {
        Task<bool> AddItemAsync(HistoryItem item);
        Task<bool> UpdateItemAsync(HistoryItem item);
        Task<bool> DeleteItemAsync(HistoryItem item);
        Task<HistoryItem> GetItemAsync(int id);
        Task<IEnumerable<HistoryItem>> GetItemsAsync(bool forceRefresh = false);
    }
}