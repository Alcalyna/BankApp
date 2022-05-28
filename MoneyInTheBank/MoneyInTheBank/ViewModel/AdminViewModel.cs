using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class AdminViewModel : ViewModelCommon
    {
        public ICommand CreateTransactionAdminCommand { get; set; }
        public AdminViewModel()
        {
            CreateTransactionAdminCommand = new RelayCommand(OpenNewTransactionAdminTab);
        }

        private void OpenNewTransactionAdminTab()
        {
            NotifyColleagues(App.Messages.OPEN_NEW_TRANSACTION_ADMIN_TAB);
        }
    }
}
