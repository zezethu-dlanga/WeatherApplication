using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Application.Interface;
using Weather_Application.Model;

namespace Weather_Application.Service
{
    public class LocalDataStore : IDataStore
    {
        List<HistoryItem> items;
        private SQLiteConnection _database;

        public LocalDataStore()
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            if (_database != null)
            {
                _database.Close();
                _database.Dispose();
                _database = null;
            }

            CreateLocalTables();
        }

        private void CreateLocalTables()
        {
            //_database.DropTable<AuthenticatedUser>();
            _database.CreateTable<HistoryItem>();
        }

        public async Task<bool> AddItemAsync(HistoryItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(HistoryItem item)
        {
            var _item = items.Where((HistoryItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(HistoryItem item)
        {
            var _item = items.Where((HistoryItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<HistoryItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<HistoryItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
