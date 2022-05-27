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
    public class ClientViewModel : ViewModelCommon
    {

        private Client? _client = null;

        public Client? Client
        {
            get => _client;
            set => SetProperty(ref _client, value, InitializeFields);
        }
        private string OriginalEmail { get; set; }

        private Agency _agency;
        public Agency Agency
        {
            get => _agency;
            set => SetProperty(ref _agency, value);
        }

        private void InitializeFields()
        {
            if (Client != null)
            {
                OriginalEmail = Client.Email;
                ConfirmedPassword = Client.Password;
            }
            else
            {
                ConfirmedPassword = ""; 
                ClearErrors();
            }
        }

        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
            }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ClientViewModel()
        {
            Register<Client>(App.Messages.DISPLAY_CLIENT_PROFILE, client => InitializeClient(client));
            Register<Agency>(App.Messages.AGENCY_SELECTED, agency => Agency = agency);
            SaveCommand = new RelayCommand(SaveAction, CanSaveAction);
            CancelCommand = new RelayCommand(CancelAction, CanCancelAction);
            DeleteCommand = new RelayCommand(DeleteAction, CanDeleteAction);
        }

        private void InitializeClient(Client client)
        {
            Client = client; 
            if(client != null && client.ClientNumber == "0000")
                IsNew = true;
            RaisePropertyChanged(); 
        }
        private bool CanSaveAction()
        {
            return Client != null && (Client.IsModified || IsNew) && !HasErrors;
        }

        private void DeleteAction()
        {
            Client.Delete();
            List<InternalAccount> internalAccounts = InternalAccount.GetAll().ToList();
            foreach(InternalAccount account in internalAccounts)
            {
                var query = ClientInternalAccount.GetInternalAccountsOwners(account);
                int count = query.Count();
                if (count == 0)
                {
                    account.Delete();
                    NotifyColleagues(App.Messages.ACCOUNT_DELETED, account);
                }
            }
            NotifyColleagues(App.Messages.CLIENT_UPDATED, Client);
            RaisePropertyChanged();
        }

        private bool CanDeleteAction()
        {
            return Client != null && !IsNew;
        }

        private bool CanCancelAction()
        {
            return Client != null && (Client.IsModified || IsNew);
        }
        public override void CancelAction()
        {
            if(IsNew)
            {
                IsNew = false;
                NotifyColleagues(App.Messages.CLIENT_UPDATED, Client);
            }
            else
            {
                ClearErrors();
                Client.Reload();
            }
            RaisePropertyChanged();
        }

        public override void SaveAction()
        {
            if (Validate())
            {
                if (IsNew)
                {
                    Client.Agency = Agency;
                    Client.Add();
                    Client.SetClientNumber();
                    IsNew = false;
                }
                Context.SaveChanges();
                NotifyColleagues(App.Messages.CLIENT_UPDATED, Client);
            }
        }
        public string Email
        {
            get => _client?.Email;
            set => SetProperty(Client.Email, value, Client, (c, v) => { c.Email = v; Validate(); });
        }
        public string FirstName
        {
            get => _client?.FirstName;
            set => SetProperty(Client.FirstName, value, Client, (c, v) => { c.FirstName = v; Validate(); });
        }
        public string LastName
        {
            get => _client?.LastName;
            set => SetProperty(Client.LastName, value, Client, (c, v) => { c.LastName = v; Validate(); });
        }
        public string Password
        {
            get => _client?.Password;
            set => SetProperty(Client.Password, value, Client, (c, v) => { c.Password = v; Validate(); });
        }
        public string _confirmedPassword;
        public string ConfirmedPassword
        {
            get => _confirmedPassword;
            set => SetProperty(ref _confirmedPassword, value, () => Validate() );
        }


        public override bool Validate()
        {
            ClearErrors();
            ValidateEmail();
            ValidateFirstName();
            ValidateLastName();
            ValidatePassword();
            return !HasErrors;
        }
        private bool ValidateEmail()
        {
            if (string.IsNullOrEmpty(Email))
                AddError(nameof(Email), "Required!");
            else if (!Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                AddError(nameof(Email), "Invalid format!");
            else if ((IsNew || !Email.Equals(OriginalEmail)) && User.GetByEmail(Email) != null)
                AddError(nameof(Email), "This email is already taken!");
            return !HasErrors;
        }
        private bool ValidateFirstName()
        {
            if (string.IsNullOrEmpty(FirstName))
                AddError(nameof(FirstName), "Required!");
            else if (FirstName.Length < 3)
                AddError(nameof(FirstName), "Enter at least 3 chars!");
            return !HasErrors;

        }
        private bool ValidateLastName()
        {
            if (string.IsNullOrEmpty(LastName))
                AddError(nameof(LastName), "Required!");
            else if (LastName.Length < 3)
                AddError(nameof(LastName), "Enter at least 3 chars!");
            return !HasErrors;
        }

        private bool ValidatePassword()
        {
            if (string.IsNullOrEmpty(Password))
                AddError(nameof(Password), "Required!");
            else if (Password.Length < 3)
                AddError(nameof(LastName), "Enter at least 3 chars!");
            if(string.IsNullOrEmpty(ConfirmedPassword))
                AddError(nameof(ConfirmedPassword), "Required!");
            else if (!Password.Equals(ConfirmedPassword))
                AddError(nameof(ConfirmedPassword), "Please enter twice the same password!");
            return !HasErrors;
        }
    }
}
