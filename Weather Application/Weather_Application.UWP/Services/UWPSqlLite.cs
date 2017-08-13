using System;
using SQLite.Net;
using Weather_Application.Interfaces;
using System.IO;
using Windows.Storage;
using Weather_Application.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPSqlLite))]
namespace Weather_Application.UWP.Services
{
    public class UWPSqlLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "Weather.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);

            var platfrom = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLiteConnection(platfrom, path);
            return connection;
        }
    }
}
