using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace MoneyInTheBank.ViewModel
{
    public class NewTransferViewModel : ViewModelCommon
    {
        public ICommand CancelCommand { get; set; }

        private InternalAccount _currentInternalAccount;
        public InternalAccount CurrentInternalAccount
        {
            get => _currentInternalAccount;
            set => SetProperty(ref _currentInternalAccount, value, () => Validate());
        }

        private ObservableCollection<string> _categoryNames;
        public ObservableCollection<string> CategoryNames
        {
            get => _categoryNames;
            set => SetProperty(ref _categoryNames, value);
        }

        private string _recipientIban;
        public string RecipientIban
        {
            get => _recipientIban;
            set => SetProperty(ref _recipientIban, value, () =>  Validate());
        }

        private Account _recipient;
        private Account Recipient
        {
            get => _recipient;
            set => SetProperty(ref _recipient, value);

        }

        private string _amount;
        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value, () => { Validate(); });
        }

        private double _amountDecimal;
        private double AmountDecimal
        {
            get => _amountDecimal;
            set => SetProperty(ref _amountDecimal, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value, () => { Validate(); });
        }

        private DateTime? _actionDateTime = null;
        public DateTime? ActionDateTime
        {
            get => _actionDateTime;
            set => SetProperty(ref _actionDateTime, value, () => Validate());
        }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value, () => Validate());
        }

        private Category _category;
        public Category Category
        {
            get => _category;
            set => SetProperty(ref _category, value, () => Validate());
        }

        private DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value, () => { Transaction.ComputeBalance(Transaction.GetAll(), value); Validate(); } );
        }

        public NewTransferViewModel()
        {
            CategoryNames = new ObservableCollection<string>(Category.GetAllNames());
            SelectRecipient = new RelayCommand(() => { SelectRecipientAction(); });
            Register<Account>(App.Messages.RECIPIENT_SELECTED, account => { RecipientIban = account.Iban; });
            TransferCommand = new RelayCommand(TransferAction, () => { return !HasErrors; });
            CancelCommand = new RelayCommand(CancelAction, CanCancelAction);
            Register<DateTime>(App.Messages.DATE_CHANGED, date => { CurrentDateTime = date; });
            SetAllInternalAccounts();
        }

        
        public override void CancelAction()
        {
            ClearErrors();
            NotifyColleagues(App.Messages.CLOSE_TRANSACTION);
        }

        private bool CanCancelAction()
        {
            return CurrentInternalAccount != null;
        }

        private void SelectRecipientAction()
        {
            if(CurrentInternalAccount != null)
            {
                bool res = (bool)App.ShowDialog<RecipientsViewModel, User, MoneyInTheBankContext>(CurrentInternalAccount);
            }
        }
        private void SetAllInternalAccounts()
        {
            var internalAccounts = GetCurrentClient().GetInternalAccounts();
            AllInternalAccounts = new ObservableCollection<InternalAccount>(internalAccounts);
        }

        private void TransferAction()
        {
            if (Validate())
            {
                Transaction transaction = new Transaction(GetCurrentClient(), AmountDecimal, CurrentInternalAccount, Recipient, CurrentDate, Description, Category, ActionDateTime);
                transaction.Add();
                ClearErrors();
                NotifyColleagues(App.Messages.TRANSACTION_CREATED);
                ClearErrors();
                NotifyColleagues(App.Messages.CLOSE_TRANSACTION);
            }
        }
        public void Init(InternalAccount currentInternalAccount)
        {
            CurrentInternalAccount = currentInternalAccount;
            RaisePropertyChanged();
        }

        public ICommand SelectRecipient { get; set; }

        public ICommand TransferCommand { get; set; }

        public override bool Validate()
        {
            ClearErrors();
            ValidateRecipient();
            ValidateAmount();
            ValidateDateActionDate();
            ValidateCategory();
            ValidateDescription();

            return !HasErrors;
        }

        private bool ValidateRecipient()
        {
            
            if (string.IsNullOrEmpty(RecipientIban))
                AddError(nameof(RecipientIban), "required");
            else
            {
                var recipient = Account.GetByIban(RecipientIban);
                if (recipient == null)
                    AddError(nameof(RecipientIban), "This account does not exist!");
                else if(CurrentInternalAccount is CheckingAccount)
                {
                    Client client = GetCurrentClient();
                    List<Account> allRecipients = new List<Account>(((CheckingAccount)CurrentInternalAccount).GetAllRecipients(client));
                    if(!allRecipients.Contains(recipient))
                        AddError(nameof(RecipientIban), "You can't send money to this account!");
                    else
                        Recipient = recipient;

                }
                else if(CurrentInternalAccount is SavingAccount)
                {
                    Client client = GetCurrentClient();
                    List<Account> allRecipients = new List<Account>(((SavingAccount)CurrentInternalAccount).GetAllRecipients(client));
                    if (!allRecipients.Contains(recipient))
                        AddError(nameof(RecipientIban), "You can't send money to this account!");
                    else
                        Recipient = recipient;
                }
                
            }
            return !HasErrors;
        }

        private bool ValidateAmount()
        {
            if(string.IsNullOrEmpty(Amount))
                AddError(nameof(Amount), "Required");
            else
            {
                double amount;
                string AmountToCheck;
                if (Amount.Substring(Amount.Length - 1) == "€")
                    AmountToCheck = Amount.Remove(Amount.Length - 1);
                else
                    AmountToCheck = Amount;
                Double.TryParse(AmountToCheck, out amount);
                if(!Double.TryParse(AmountToCheck, out amount))
                    AddError(nameof(Amount), "Invalid format");
                else if (amount <= 0)
                    AddError(nameof(Amount), "The amount should be at least 0.01 €");
                else if (ActionDateTime == null && CurrentInternalAccount.IsSolvent(amount))
                    AddError(nameof(Amount), "Max amount is " + CurrentInternalAccount.GetMaxAmount() + " €!");
                else
                    AmountDecimal = amount;
            }
            
            return !HasErrors;
        }
        
        private bool ValidateDateActionDate()
        {
            if (ActionDateTime <= CurrentDateTime)
                AddError(nameof(ActionDateTime), "The action time should be in the future");
            return !HasErrors;
        }

        private bool ValidateCategory()
        {
            if (!string.IsNullOrEmpty(CategoryName) && Category.GetByName(CategoryName) == null)
                AddError(nameof(CategoryName), "This category doesn't exist!");
            else
                Category = Category.GetByName(CategoryName);
            return !HasErrors;
        }

        private bool ValidateDescription()
        {
            if (string.IsNullOrEmpty(Description))
                AddError(nameof(Description), "Required");
            return !HasErrors;
        }

        private ObservableCollection<InternalAccount> _allInternalAccounts;
        public ObservableCollection<InternalAccount> AllInternalAccounts
        {
            get => _allInternalAccounts;
            set => SetProperty(ref _allInternalAccounts, value);
        }
    }
}
