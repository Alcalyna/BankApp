using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class MainViewModel : ViewModelCommon
    {
        public event Action CloseTransaction;
        public ICommand LogoutCommand { get; set; }
        public ObservableCollectionFast<Client> Clients { get; set; } = new();

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value, () => { NotifyColleagues(App.Messages.DATE_CHANGED, value); CurrentDate = SelectedDate; });
        }

        public MainViewModel()
        { 
            SelectedDate = new DateTime(2022,1,12);
            LogoutCommand = new RelayCommand(Logout);
            Register(App.Messages.CLOSE_TRANSACTION, () => { ClearErrors(); CloseTransaction?.Invoke(); });
        }

        private void Logout()
        {
            ClearErrors();
            NotifyColleagues(App.Messages.MSG_LOGOUT);
        }
        public static string Title
        {
            get => $"Money in the bank of {CurrentUser?.FirstName} {CurrentUser?.LastName}";
        }

    }
}
