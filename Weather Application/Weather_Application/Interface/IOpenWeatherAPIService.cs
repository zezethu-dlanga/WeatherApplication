using System.Collections.Generic;
using System.Threading.Tasks;
using Weather_Application.Model;

namespace Weather_Application.Interface
{
    public interface IOpenWeatherAPIService
    {
        Task<RootObject> GetCityAsync(string cityName);
    }
}
