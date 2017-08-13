using System.Threading.Tasks;
using Weather_Application.Model;

namespace Weather_Application.Interfaces
{
    public interface IOpenWeatherAPIService
    {
        Task<RootObject> GetCityWeatherAsync(string cityName);
    }
}
