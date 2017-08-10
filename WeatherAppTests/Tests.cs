using NUnit.Framework;
using Weather_Application.Service;

namespace WeatherAppTests
{
    [TestFixture()]
    public class Test
    {
        OpenWeatherAPIService _apiService;

        [SetUp]
        public void Satup()
        {
            _apiService = new OpenWeatherAPIService();
        }

        [Test]
        public void GetCityAsync_Return_Expected_Information()
        {
            var cityName = "Alberton";
            var result = _apiService.GetCityAsync(cityName);
            Assert.That(result, Is.Not.Null);
        }
        
    }
}

