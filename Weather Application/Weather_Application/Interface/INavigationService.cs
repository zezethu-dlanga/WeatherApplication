using System;
using Weather_Application.Enum;
using Xamarin.Forms;

namespace Weather_Application.Interface
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(AppPages pageKey);
        void NavigateTo(AppPages pageKey, object parameter);
        void Configure(AppPages pageKey, Type pageType);
        void Initialize(NavigationPage navigation);
    }
}
