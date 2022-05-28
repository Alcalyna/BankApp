using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class RecipientsViewModel : DialogViewModelBase<User, MoneyInTheBankContext>
    {
        public RecipientsViewModel()
        {
            SelectRecipientCommand = new RelayCommand(SelectRecipientAction, CanSelectRecipient);
            CancelCommand = new RelayCommand(() => { DialogResult = true; });
            ClearFilter = new RelayCommand(() => Filter = "");
        }

        private Account _selectedRecipient;
        public Account SelectedRecipient
        {
            get => _selectedRecipient;
            set => SetProperty(ref _selectedRecipient, value);
        }

        private void SelectRecipientAction()
        {
            NotifyColleagues(App.Messages.RECIPIENT_SELECTED, SelectedRecipient); 
            DialogResult = true;
        }

        private bool CanSelectRecipient()
        {
            return SelectedRecipient != null;
        }
        private static bool IsClient => App.IsLoggedIn && App.CurrentUser is Client;
        private Client GetCurrentClient()
        {
            if (IsClient)
                return (Client)App.CurrentUser;
            else
                return null;
        }

        private InternalAccount _currentInternalAccount;
        public InternalAccount CurrentInternalAccount
        {
            get => _currentInternalAccount;
            set => SetProperty(ref _currentInternalAccount, value, SetData);
        }
        private void SetData()
        {
            IsCheckingAccount = CurrentInternalAccount is CheckingAccount;
            Console.WriteLine(IsCheckingAccount);
            RefreshData();
        }

        private ObservableCollection<Account> _ownOtherAccounts = new();
        public ObservableCollection<Account> OwnOtherAccounts
        {
            get => _ownOtherAccounts;
            set => SetProperty(ref _ownOtherAccounts, value);
        }

        private ObservableCollection<Account> _otherAccounts = new();
        public ObservableCollection<Account> OtherAccounts
        {
            get => _otherAccounts;
            set => SetProperty(ref _otherAccounts, value);
        }

        public ICommand SetRecipient { get; set; }
        public ICommand SelectRecipientCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private bool _isCheckingAccount;
        public bool IsCheckingAccount
        {
            get => _isCheckingAccount;
            set => SetProperty(ref _isCheckingAccount, value, RaisePropertyChanged);
        }

        public void RefreshData()
        {
            Client Client = GetCurrentClient();
            OwnOtherAccounts.Clear();
            OtherAccounts.Clear();
            if (IsCheckingAccount)
            {
                IQueryable<Account> ownAccounts = string.IsNullOrEmpty(Filter) ? ((CheckingAccount)CurrentInternalAccount).GetAllOwnRecipients(Client) : ((CheckingAccount)CurrentInternalAccount).GetAllOwnRecipientsFiltered(Filter, Client);
                IQueryable<Account> otherAccounts = string.IsNullOrEmpty(Filter) ? ((CheckingAccount)CurrentInternalAccount).GetAllOtherRecipients(Client) : ((CheckingAccount)CurrentInternalAccount).GetAllOtherRecipientsFiltered(Filter, Client);
                OwnOtherAccounts = new ObservableCollection<Account>(ownAccounts);
                OtherAccounts = new ObservableCollection<Account>(otherAccounts);
            }
            else
            {
                IQueryable<Account> ownAccounts = string.IsNullOrEmpty(Filter) ? ((SavingAccount)CurrentInternalAccount).GetAllRecipients(Client) : ((CheckingAccount)CurrentInternalAccount).GetAllOtherRecipientsFiltered(Filter, Client);
                OwnOtherAccounts = new ObservableCollection<Account>(ownAccounts);
            }
            RaisePropertyChanged();
        }
        private string _filter;
        public string Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value, () => { Console.WriteLine(value); RefreshData(); });
        }
        public ICommand ClearFilter { get; set; }
    }
}
