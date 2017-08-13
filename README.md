# WeatherApplication
Weather Application

The application allows a user to get weather information of a specific city he or she types in.
Automatically saves weather history of each city previously looked for.
Can see a list of all previously looked at cities.
Can delete all saved weather data.

-------------------------------------------------------------------------------------------------------------------------------------

Created Blank Xamarin.Forms PCL Project that consist of Weather_Application.Android, Weather_Application.iOS, and Weather_Application.UWP.
Added the MvvmLight Package in all projects to get started in the Model-View-ViewModel pattern.
Connect to openweathermap api to get the city weather information.
Included Xam.Plugin.Connectivity to check the availability of internet connection.
Included SQLite to have local storage.
