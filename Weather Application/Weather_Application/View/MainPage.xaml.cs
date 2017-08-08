using Weather_Application.Interface;
using Weather_Application.Service;
using Xamarin.Forms;

namespace Weather_Application
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
        }
    }
}