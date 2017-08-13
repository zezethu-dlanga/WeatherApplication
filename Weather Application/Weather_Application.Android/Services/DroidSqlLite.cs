using System;
using SQLite.Net;
using Weather_Application.Interfaces;
using System.IO;
using Weather_Application.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidSqlLite))]
namespace Weather_Application.Droid.Services
{
    public class DroidSqlLite : ISQLite
    {

        public SQLiteConnection GetConnection()
        {
            var filename = "Weather.db3";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}