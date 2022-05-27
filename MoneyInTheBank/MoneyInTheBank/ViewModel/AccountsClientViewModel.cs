using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PRBD_Framework;
using MoneyInTheBank.Model;
using static MoneyInTheBank.Model.ClientInternalAccount;
using System.Text.RegularExpressions;

namespace MoneyInTheBank.ViewModel
{
    public class AccountsClientViewModel : ViewModelCommon
    {

        private Client _client;

        public Client Client
        {
            get => _client;
            set => SetProperty(ref _client, value, SetAccounts);
        }

        private ObservableCollection<InternalAccount> _internalAccounts = new();
        public ObservableCollection<InternalAccount> InternalAccounts
        {
            get => _internalAccounts;
            set => SetProperty(ref _internalAccounts, value);
        }
        public DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value, () => { UpdateBalance(); });
        }
        public AccountsClientViewModel()
        {
            Register<Client>(App.Messages.DISPLAY_CLIENT_PROFILE, client => SelectClient(client));
            Register<DateTime>(App.Messages.DATE_CHANGED, date => { CurrentDateTime = date; });
            CurrentDateTime = CurrentDate;
            Relations = new ObservableCollection<RelationType>(ClientInternalAccount.GetAllRelationTypes());
            SelectedRelation = ClientCheckingAccount.RelationType.OWNER;
            AddRelationCommand = new RelayCommand(AddRelationAction, CanAddRelationAction);
            SaveCommand = new RelayCommand(SaveAction, CanSaveAction);
            DeleteCommand = new RelayCommand(DeleteAction, CanDeleteAction);
            CancelCommand = new RelayCommand(CancelAction, CanCancelAction); 
            CheckInternalAccountCommand = new RelayCommand<InternalAccount>(internalAccount => { NotifyColleagues(App.Messages.DISPLAY_INTERNAL_ACCOUNT, internalAccount); });
        }

        private void SelectClient(Client client)
        {
            Client = client; 
            RaisePropertyChanged();
        }

        private InternalAccount _selectedAccountToUpdate;
        public InternalAccount SelectedAccountToUpdate
        {
            get => _selectedAccountToUpdate;
            set => SetProperty(ref _selectedAccountToUpdate, value);
        }
        private bool CanDeleteAction()
        {
            var query = ClientInternalAccount.GetInternalAccountsOwners(SelectedAccountToUpdate);
            int numberOfOwners = query.Count();
            return (SelectedAccountToUpdate != null && InternalAccounts.Contains(SelectedAccountToUpdate) && (SelectedAccountToUpdate.Relation == RelationType.PROXY || numberOfOwners > 1));
        }
        private void DeleteAction()
        {
            ClientInternalAccount clientInternalAccount = ClientInternalAccount.GetByClientAndInternalAccount(Client, SelectedAccountToUpdate);
            clientInternalAccount.Delete();
            InternalAccounts.Clear();
            NotifyColleagues(App.Messages.REMOVE_ACCOUNT_FROM_USER);
        }
        private bool CanAddRelationAction()
        {
            return Client != null && SelectedAccount != null; 
        }

        private void AddRelationAction()
        {
            ClientInternalAccount clientInternalAccount = new ClientInternalAccount { Client = Client, InternalAccount = SelectedAccount, Relation = SelectedRelation };
            ToUpdateList.Add(clientInternalAccount);
            InternalAccounts.Add(SelectedAccount);
            SelectedAccount.Relation = SelectedRelation;
            OtherInternalAccounts.Remove(SelectedAccount);
            UpdateBalance();
            RaisePropertyChanged();
        }

        public override void SaveAction()
        {
            foreach (var clientInternalAccount in ToUpdateList)
                clientInternalAccount.Add();
            ToUpdateList.Clear();
            InternalAccounts.Clear();
            NotifyColleagues(App.Messages.ADD_ACCOUNT_TO_USER);
        }

        private bool CanCancelAction() 
        {
            return ToUpdateList.Count > 0;
        }

        public override void CancelAction()
        {
            ToUpdateList.Clear();
            SetOtherInternalAccounts();
            SetAccounts();
        }

        private ObservableCollection<ClientInternalAccount> _toUpdateList = new();
        public ObservableCollection<ClientInternalAccount> ToUpdateList
        {
            get => _toUpdateList;
            set => SetProperty(ref _toUpdateList, value);
        }

        private bool CanSaveAction()
        {
            return ToUpdateList.Count > 0;
        }

        private void UpdateBalance()
        {
            IQueryable<Transaction> transactions = Transaction.GetAll();
            foreach (var Account in InternalAccounts)
                Transaction.SetProperties(transactions, CurrentDateTime, Account);
        }
        private void SetAccounts()
        {
            if(Client != null && Client.ClientNumber != "0000")
            {
                InternalAccounts = new ObservableCollection<InternalAccount>(Client.GetAllAccounts());
                SetRelations();
                SetOtherInternalAccounts();
                UpdateBalance();
                RaisePropertyChanged();
            }
        }

        private void SetRelations()
        {
            foreach (var account in InternalAccounts)
                account.Relation = account.GetRelationType(Client);
        }

        private ObservableCollection<RelationType> _relations = new();
        public ObservableCollection<RelationType> Relations
        {
            get => _relations;
            set => SetProperty(ref _relations, value);
        }

        private RelationType _selectedRelation;
        public RelationType SelectedRelation
        {
            get => _selectedRelation;
            set => SetProperty(ref _selectedRelation, value);
        }

        private ObservableCollection<InternalAccount> _otherInternalAccounts = new();
        public ObservableCollection<InternalAccount> OtherInternalAccounts
        {
            get => _otherInternalAccounts;
            set => SetProperty(ref _otherInternalAccounts, value);
        }

        private void SetOtherInternalAccounts()
        {
            if(Client != null)
            {
                List<InternalAccount> all = Client.GetOtherInternalAccounts();
                OtherInternalAccounts = new ObservableCollection<InternalAccount>(all);
            }
        }

        public ICommand AddRelationCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand CheckInternalAccountCommand { get; set; }

        private InternalAccount _selectedAccount;

        public InternalAccount SelectedAccount
        {
            get => _selectedAccount;
            set => SetProperty(ref _selectedAccount, value);
        }
    }
}
