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
        private bool _displayErrorMsg, _isRefreshing;
        private string _errorMsg;

        public ICommand RefreshCommand { protected set; get; }
        public ICommand DeleteAllCommand { protected set; get; }
        
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged();
            }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; RaisePropertyChanged(); }
        }

        public bool DisplayErrorMsg
        {
            get { return _displayErrorMsg; }
            set { _displayErrorMsg = value; RaisePropertyChanged(); }
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
            RefreshCommand = new Command(Refresh);
            DeleteAllCommand = new Command(DeleteAll);

            RetrieveHistoryList();
        }

        public void Refresh()
        {
            IsRefreshing = true;
            RetrieveHistoryList();
            IsRefreshing = false;
        }

        public void DeleteAll()
        {
            _dataStore.DeleteAllWeatherHistory();
            Refresh();
        }

        public void RetrieveHistoryList()
        {
            HistoryItems = _dataStore.GetAllWeatherHistory();

            if(!HistoryItems.Count.Equals(0))
            {
                DisplayErrorMsg = false;

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
            else
            {
                HistoryDataItem = null;
                DisplayErrorMsg = true;
                ErrorMsg = "You have no weather history.";
            }
        }
    }
}
