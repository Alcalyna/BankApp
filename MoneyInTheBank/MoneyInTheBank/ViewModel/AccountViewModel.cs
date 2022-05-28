using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class AccountViewModel: ViewModelCommon
    {

        private ObservableCollection<InternalAccount> _internalAccounts = new();
        public ObservableCollection<InternalAccount> InternalAccounts
        {
            get => _internalAccounts;
            set => SetProperty(ref _internalAccounts, value, UpdateAccounts);
        }

        private string _filter;
        public string Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value, OnRefreshData);
        }

        private bool _checkingAccountsSelected;
        public bool CheckingAccountsSelected
        {
            get => _checkingAccountsSelected;
            set => SetProperty(ref _checkingAccountsSelected, value, OnRefreshData);
        }

        private bool _savingAccountsSelected;
        public bool SavingAccountsSelected
        {
            get => _savingAccountsSelected;
            set => SetProperty(ref _savingAccountsSelected, value, OnRefreshData);
        }

        private bool _allSelected;
        public bool AllSelected
        {
            get => _allSelected;
            set => SetProperty(ref _allSelected, value, OnRefreshData);
        }

        private void UpdateAccounts()
        {
            SetProperties(); 
            UpdateBalance(); 
        }

        private Client _currentClient;
        public Client CurrentClient
        {
            get => _currentClient;
            set => SetProperty(ref _currentClient, value);
        }

        public DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value, OnRefreshData);
        }

        public ICommand Statement { get; set; }
        public ICommand NewTransfer { get; set; }
        public ICommand ClearFilter { get; set; }


        public AccountViewModel()
        {
            CurrentClient = GetCurrentClient();
            if (IsClient)
            {
                AllSelected = true;
                CurrentDateTime = CurrentDate;
            }
            ClearFilter = new RelayCommand(() => Filter = "");
            Statement = new RelayCommand<InternalAccount>(internalAccount => { NotifyColleagues(App.Messages.DISPLAY_INTERNAL_ACCOUNT, internalAccount); });
            NewTransfer = new RelayCommand<InternalAccount>(internalAccount => { NotifyColleagues(App.Messages.NEW_TRANSFER, internalAccount); });
            Register<DateTime>(App.Messages.DATE_CHANGED, date => { CurrentDateTime = date; });
            Register(App.Messages.TRANSACTION_CREATED, () => { OnRefreshData(); });
        }

        private void UpdateBalance()
        {
            IQueryable<Transaction> transactions = Transaction.GetAll();
            Transaction.ComputeBalance(transactions, CurrentDateTime);
        }
 
        private void SetProperties()
        {
            foreach(var account in InternalAccounts)
            {
                account.Relation = account.GetRelationType(CurrentClient);
                account.Type = GetTypeName(account);
            }
        }

        private string GetTypeName(InternalAccount internalAccount)
        {
            return Context.InternalAccounts.SingleOrDefault(a => a == internalAccount).GetType().Name;
        }

        protected override void OnRefreshData()
        {
            if (_checkingAccountsSelected && _savingAccountsSelected ||
                _checkingAccountsSelected && _allSelected ||
                _savingAccountsSelected && _allSelected)
                return;
            IQueryable<InternalAccount> internalAccounts = string.IsNullOrEmpty(Filter) ? InternalAccount.GetAll() : InternalAccount.GetFiltered(Filter);
            var filteredInternalAccounts = from ia in internalAccounts
                                           where
                                      CheckingAccountsSelected && ia.ClientInternalAccounts.Any(cia => cia.Client == CurrentClient) && ia is CheckingAccount ||
                                      SavingAccountsSelected && ia.ClientInternalAccounts.Any(cia => cia.Client == CurrentClient) && ia is SavingAccount ||
                                      AllSelected && ia.ClientInternalAccounts.Any(cia => cia.Client == CurrentClient)
                                  select ia;
            InternalAccounts = new ObservableCollection<InternalAccount>(filteredInternalAccounts);
        }

    }
}
