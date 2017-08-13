using GalaSoft.MvvmLight.Ioc;
using Weather_Application.Enum;
using Weather_Application.Interfaces;
using Weather_Application.View;
using Weather_Application.ViewModel;
using Xamarin.Forms;

namespace Weather_Application
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public App()
        {
            InitializeComponent();

            INavigationService navigationService;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigationService = new Service.NavigationService();

                // Configure pages:
                navigationService.Configure(AppPages.MainPage, typeof(MainPage));
                navigationService.Configure(AppPages.History, typeof(HistoryPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }
            else
            {
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            }
            // Create new Navigation Page and set LoginPage as its default page:

            var firstPage = new NavigationPage(new MainPage());
            // Set Navigation page as default page for Navigation Service:
            navigationService.Initialize(firstPage);

            // You have to also set MainPage property for the app:
            MainPage = firstPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
