using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Application.Interface;
using Weather_Application.Model;

namespace Weather_Application.Service
{
    public class OpenWeatherAPIService : IOpenWeatherAPIService
    {
        public async Task<RootObject> GetCityWeatherAsync(string cityName)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org/")
            };
            
            try
            {
                var response = await client.GetAsync("data/2.5/weather?q=" + cityName + "&appid=2ad5f9d7db7f02f4bafa8821f04f2679");
                var placesJson = response.Content.ReadAsStringAsync().Result;

                var locationData = JsonConvert.DeserializeObject<RootObject>(placesJson);

                return locationData;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            finally
            {
                client.Dispose();
            }

            return null;
        }
    }
}
