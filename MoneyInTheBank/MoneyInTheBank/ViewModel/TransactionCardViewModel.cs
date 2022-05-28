using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public enum Status
    {
        REFUSED, EXECUTED, NOT_EXECUTED, NOT_DISPLAYED
    }
    public class TransactionCardViewModel : ViewModelCommon
    {
        private double _amountToDisplay;
        public double AmountToDisplay
        {
            get => _amountToDisplay;
            set => SetProperty(ref _amountToDisplay, value, RaisePropertyChanged);
        }

        private double _temporaryBalance;
        public double TemporaryBalance
        {
            get => _temporaryBalance;
            set => SetProperty(ref _temporaryBalance, value, RaisePropertyChanged);
        }
        public ICommand CancelTransactionCommand { get; set; }
        public TransactionCardViewModel(Transaction transaction, InternalAccount internalAccount)
        {
            Transaction = transaction;
            InternalAccount = internalAccount;
            CancelTransactionCommand = new RelayCommand(DeleteTransaction, CanDeleteTransaction);
            SetProperties(Transaction.GetAll(), CurrentDate, InternalAccount);
        }

        private bool CanDeleteTransaction()
        {
            return Transaction.TransactionStatus == Status.NOT_EXECUTED;
        }

        private void DeleteTransaction()
        {
            Transaction.Delete();
            ClearErrors();
            NotifyColleagues(App.Messages.TRANSACTION_CANCELED);
        }

        private InternalAccount _internalAccount;
        public InternalAccount InternalAccount
        {
            get => _internalAccount;
            set => SetProperty(ref _internalAccount, value);
        }


        private Transaction _transaction;
        public Transaction Transaction
        {
            get => _transaction;
            set => SetProperty(ref _transaction, value);
        }


        private ObservableCollection<Category> _categories = new();
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public Category SelectedCategory
        {
            get
            {
                return Transaction?.Category;
            }
            set
            {
                if (value.Name == "")
                    Transaction.Category = null;
                else
                    Transaction.Category = value;
                Context.SaveChanges();
                NotifyColleagues(App.Messages.CATEGORY_CHANGED, Transaction);
            }
        }

        public void SetProperties(IQueryable<Transaction> transactions, DateTime CurrentDateTime, InternalAccount CurrentAccount)
        {
            SetAmountToDisplay(CurrentAccount);
            InternalAccount.ResetTemporaryBalanceAccounts();
            SetTemporaryBalance(transactions, CurrentAccount);
        }

        private void SetTemporaryBalance(IQueryable<Transaction> transactions, InternalAccount CurrentAccount)
        {
            TemporaryBalance = 0;
            foreach (var t in transactions)
            {
                if (Transaction.ActionDateTime <= t.ActionDateTime && t.ActionDateTime <= CurrentDate)
                {
                    if (t.Source is ExternalAccount)
                    {
                        ((InternalAccount)t.Recipient).TemporaryBalance += t.Amount;
                        if (((InternalAccount)t.Recipient).AccountId == CurrentAccount.AccountId)
                            TemporaryBalance = ((InternalAccount)t.Recipient).TemporaryBalance;
                    }
                    else
                    {
                        InternalAccount Source = (InternalAccount)t.Source;
                        if (Source.TemporaryBalance - t.Amount >= Source.LowerLimit)
                        {
                            Source.TemporaryBalance -= t.Amount;
                            if (Source.AccountId == CurrentAccount.AccountId)
                                TemporaryBalance = Source.TemporaryBalance;
                            if (t.Recipient is InternalAccount)
                            {
                                InternalAccount Recipient = (InternalAccount)t.Recipient;
                                Recipient.TemporaryBalance += t.Amount;
                                if (Recipient.AccountId == CurrentAccount.AccountId)
                                    TemporaryBalance = Recipient.TemporaryBalance;
                            }
                        }
                        else
                        {
                            if (Source.AccountId == CurrentAccount.AccountId)
                                TemporaryBalance = Source.TemporaryBalance;
                        }
                    }
                }

            }
        }

        private void SetAmountToDisplay(InternalAccount CurrentAccount)
        {
            if (Transaction.Source.AccountId == CurrentAccount.AccountId)
                AmountToDisplay = Transaction.Amount * -1;
            else
                AmountToDisplay = Transaction.Amount;
        }
    }
}
