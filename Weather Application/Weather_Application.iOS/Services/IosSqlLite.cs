using System;
using SQLite.Net;
using Weather_Application.Interfaces;
using System.IO;
using Xamarin.Forms;
using Weather_Application.iOS.Services;

[assembly: Dependency(typeof(IosSqlLite))]

namespace Weather_Application.iOS.Services
{
    public class IosSqlLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "Weather.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}