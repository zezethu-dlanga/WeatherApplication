using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Application.Interface;
using Weather_Application.Model;

namespace Weather_Application.Service
{
    public class OpenWeatherAPIService : IOpenWeatherAPIService
    {
        
        public async Task<RootObject> GetCityAsync(string cityName)
        {
            var url = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid=2ad5f9d7db7f02f4bafa8821f04f2679";
            
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);

                    var result = JsonConvert.DeserializeObject<RootObject>(response);
                    return result;
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
}
