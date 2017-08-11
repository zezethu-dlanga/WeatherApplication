using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Weather_Application.Interface;
using Weather_Application.Service;

namespace Weather_Application.ViewModel
{
    /// <summary>
    /// This class provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Create loose coupling in the application
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IOpenWeatherAPIService, OpenWeatherAPIService>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}