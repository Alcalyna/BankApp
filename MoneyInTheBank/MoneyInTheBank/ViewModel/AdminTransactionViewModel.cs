using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class AdminTransactionViewModel : ViewModelCommon
    {
        public ICommand CancelCommand { get; set; }
        public ICommand TransferCommand { get; set; }
        public ICommand AddExternalAccountCommand { get; set; }
        public ICommand GenerateRandomIbanCommand { get; set; }

        public AdminTransactionViewModel()
        {
            CategoryNames = new ObservableCollection<string>(Category.GetAllNames());
            RefreshExternalAccounts();
            InternalAccounts = new ObservableCollection<InternalAccount>(InternalAccount.GetAll());
            AddExternalAccountCommand = new RelayCommand(AddExternalAccountAction, CanAddExternalAccountAction);
            GenerateRandomIbanCommand = new RelayCommand(GenerateIbanAction);
            TransferCommand = new RelayCommand(TransferAction, CanTransferAction);
            CancelCommand = new RelayCommand(CancelAction);
            CurrentDateTime = CurrentDate;
            Register<DateTime>(App.Messages.DATE_CHANGED, date => { CurrentDateTime = date; });
        }

        private ObservableCollection<string> _externalAccountIbans;

        public ObservableCollection<string> ExternalAccountIbans
        {
            get => _externalAccountIbans;
            set => SetProperty(ref _externalAccountIbans, value);
        }

        private ObservableCollection<InternalAccount> _internalAccounts;

        public ObservableCollection<InternalAccount> InternalAccounts
        {
            get => _internalAccounts;
            set => SetProperty(ref _internalAccounts, value);
        }

        private ObservableCollection<ExternalAccount> _externalAccounts;

        public ObservableCollection<ExternalAccount> ExternalAccounts
        {
            get => _externalAccounts;
            set => SetProperty(ref _externalAccounts, value);
        }

        private ExternalAccount _selectedExternalAccount;
        public ExternalAccount SelectedExternalAccount
        {
            get => _selectedExternalAccount;
            set => SetProperty(ref _selectedExternalAccount, value);
        }

        private string _selectedExternalAccountIban;
        public string SelectedExternalAccountIban
        {
            get => _selectedExternalAccountIban;
            set => SetProperty(ref _selectedExternalAccountIban, value, () => { Validate(); });
        }

        private InternalAccount _selectedInternalAccount;
        public InternalAccount SelectedInternalAccount
        {
            get => _selectedInternalAccount;
            set => SetProperty(ref _selectedInternalAccount, value);
        }

        private ObservableCollection<string> _categoryNames;
        public ObservableCollection<string> CategoryNames
        {
            get => _categoryNames;
            set => SetProperty(ref _categoryNames, value);
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
            set => SetProperty(ref _currentDateTime, value, () => Validate());
        }

        private bool CanAdd = false;
        private bool CanAddExternalAccountAction()
        {
            return CanAdd;
        }

        private void AddExternalAccountAction()
        {
            Account account = new ExternalAccount { Iban = (new IBAN(SelectedExternalAccountIban)).ToString(), Description = ExternalAccountDescription };
            account.Add();
            RefreshExternalAccountFeatures();
            RefreshExternalAccounts();
        }

        private void RefreshExternalAccountFeatures()
        {
            DescriptionVisible = false;
            CanAdd = false;
            ExternalAccountDescription = null;
        }

        private void RefreshExternalAccounts()
        {
            ExternalAccountIbans = new ObservableCollection<string>(ExternalAccount.GetAllIbans());
        }

        private void GenerateIbanAction()
        {
            SelectedExternalAccountIban = IBAN.Random().ToString();
            RaisePropertyChanged();
        }
        public override void CancelAction()
        {
            ClearErrors();
            NotifyColleagues(App.Messages.CLOSE_NEW_TRANSACTION_ADMIN);
        }

        private string _externalAccountDescription;
        public string ExternalAccountDescription
        {
            get => _externalAccountDescription;
            set => SetProperty(ref _externalAccountDescription, value, () => { Validate(); });
        }

        private bool CanTransferAction()
        {
            return Validate();
        }

        private void TransferAction()
        {
            if (Validate())
            {
                Transaction transaction = new Transaction(GetCurrentAdmin(), AmountDecimal, SelectedExternalAccount, SelectedInternalAccount, CurrentDateTime, Description, Category, ActionDateTime);
                transaction.Add();
                ClearErrors();
                NotifyColleagues(App.Messages.CLOSE_NEW_TRANSACTION_ADMIN);
                ClearErrors();
                NotifyColleagues(App.Messages.TRANSACTION_CREATED);
            }
        }

        private bool _descriptionVisible;
        public bool DescriptionVisible
        {
            get => _descriptionVisible;
            set => SetProperty(ref _descriptionVisible, value);
        }

        public override bool Validate()
        {
            ClearErrors();
            ValidateSource();
            ValidateRecipient();
            ValidateAmount();
            ValidateDateActionDate();
            ValidateCategory();
            ValidateDescription();
            ValidateExternalAccountDescription();

            return !HasErrors;
        }

        private bool ValidateExternalAccountDescription()
        {
            if (DescriptionVisible && string.IsNullOrEmpty(ExternalAccountDescription))
                AddError(nameof(ExternalAccountDescription), "Required");
            else if(DescriptionVisible)
                CanAdd = true;
            return !HasErrors;
        }
        private bool ValidateSource()
        {

            if (string.IsNullOrEmpty(SelectedExternalAccountIban))
            {
                AddError(nameof(SelectedExternalAccountIban), "Required");
                RefreshExternalAccountFeatures();
            }
            else
            {
                string Iban = SelectedExternalAccountIban.ToUpper().Replace(" ", "");
                if (!IBAN.IsValidIban(Iban))
                {
                    RefreshExternalAccountFeatures();
                    AddError(nameof(SelectedExternalAccountIban), "Invalid format!");
                }
                else 
                {
                    IBAN ibanObj = new IBAN(Iban);
                    Account account = Account.GetByIban(ibanObj.ToString());
                    if (account == null)
                    {
                        AddError(nameof(SelectedExternalAccountIban), "Please add this account first!");
                        DescriptionVisible = true;
                    }
                    else if (account is not ExternalAccount)
                    {
                        RefreshExternalAccountFeatures();
                        AddError(nameof(SelectedExternalAccountIban), "You can't only add transaction from an external account!");
                    }
                    else
                        SelectedExternalAccount = (ExternalAccount)account;
                }
            }
            return !HasErrors;
        }

        private bool ValidateRecipient()
        {
            if(SelectedInternalAccount == null)
                AddError(nameof(SelectedInternalAccount), "Required");
            return !HasErrors;
        }

        private bool ValidateAmount()
        {
            if (string.IsNullOrEmpty(Amount))
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
                if (!Double.TryParse(AmountToCheck, out amount))
                    AddError(nameof(Amount), "Invalid format");
                else if (amount <= 0)
                    AddError(nameof(Amount), "The amount should be at least 0.01 €");
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

    }
}
