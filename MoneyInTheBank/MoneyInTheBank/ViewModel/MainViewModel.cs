using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using MoneyInTheBank.Model;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class MainViewModel : ViewModelCommon
    {
        public ICommand ReloadDataCommand { get; set; }
        public ObservableCollectionFast<Client> Clients { get; set; } = new();

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value, () => { NotifyColleagues(App.Messages.DATE_CHANGED, value); CurrentDate = SelectedDate; });
        }

        public MainViewModel()
        {
            ReloadDataCommand = new RelayCommand(() =>
            {
                if (Context.ChangeTracker.HasChanges()) return;
                App.ClearContext();
                NotifyColleagues(ApplicationBaseMessages.MSG_REFRESH_DATA);
            });
            SelectedDate = new DateTime(2022,1,12);

        }


        public static string Title
        {
            get => $"Money in the bank of {CurrentUser?.FirstName} {CurrentUser?.LastName}";
        }

    }
}
