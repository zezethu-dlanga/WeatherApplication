using SQLite.Net;

namespace Weather_Application.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}