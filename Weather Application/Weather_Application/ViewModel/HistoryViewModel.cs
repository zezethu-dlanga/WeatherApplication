using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Weather_Application.Interfaces;
using Weather_Application.Model;
using Xamarin.Forms;

namespace Weather_Application.ViewModel
{
    public class HistoryViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IDataStore _dataStore;

        public IList<HistoryItem> _historyItems;
        private ObservableCollection<HistoryRowViewModel> _historyDataItem;
        private HistoryRowViewModel _historyRowViewModel;

        public ICommand RefreshCommand { protected set; get; }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged();
            }
        }

        public IList<HistoryItem> HistoryItems
        {
            get { return _historyItems; }
            set { _historyItems = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<HistoryRowViewModel> HistoryDataItem
        {
            get { return _historyDataItem; }
            set { _historyDataItem = value; RaisePropertyChanged(); }
        }

        public HistoryRowViewModel HistoryRowViewModel
        {
            get { return _historyRowViewModel; }
            set { _historyRowViewModel = value; RaisePropertyChanged(); }
        }

        public HistoryViewModel(INavigationService navigationService, IDataStore dataStore)
        {
            _navigationService = navigationService;
            _dataStore = dataStore;
            RefreshCommand = new Command(() => Refresh());

            RetrieveHistoryList();
        }

        public void Refresh()
        {
            IsRefreshing = true;
            RetrieveHistoryList();
            IsRefreshing = false;
        }

        public void RetrieveHistoryList()
        {
            HistoryItems = _dataStore.GetAllWeatherHistory();

            if(HistoryItems != null)
            {
                var data = HistoryItems.Select(
                x => new HistoryRowViewModel()
                {
                    HistoryDataItem = x,
                    Id = x.Id,
                    City = x.City,
                    TempDescription = x.TempDescription,
                    WeatherIcon = x.WeatherIcon,
                    Temp = x.Temp,
                    MinTemp = x.MinTemp,
                    MaxTemp = x.MaxTemp,
                    SearchDate = x.SearchDate.ToString("g")
                });

                HistoryDataItem = new ObservableCollection<HistoryRowViewModel>(data);
            }
        }
    }
}
