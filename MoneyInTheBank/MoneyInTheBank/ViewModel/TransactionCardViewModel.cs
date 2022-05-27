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
using System.ComponentModel;

namespace MoneyInTheBank.ViewModel
{
    public enum Status
    {
        REFUSED, EXECUTED, NOT_EXECUTED, NOT_DISPLAYED
    }
    public class TransactionCardViewModel : ViewModelCommon
    {
        public ICommand CancelTransactionCommand { get; set; }
        public TransactionCardViewModel(Transaction transaction)
        {
            Transaction = transaction;
            CancelTransactionCommand = new RelayCommand(DeleteTransaction, CanDeleteTransaction);
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
                Transaction.Category = value;
                Context.SaveChanges();
                RaisePropertyChanged(nameof(SelectedCategory));
                NotifyColleagues(App.Messages.CATEGORY_CHANGED, Transaction);
            }
        }
    }
}
