using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRBD_Framework;
using MoneyInTheBank.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PRBD_Framework;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyInTheBank.View
{
    public partial class MainView : WindowBase
    {
        public MainView()
        {
            InitializeComponent();

            Register<InternalAccount>(App.Messages.DISPLAY_INTERNAL_ACCOUNT,
                internalAccount => DoDisplayInternalAccount(internalAccount));

            Register<InternalAccount>(App.Messages.NEW_TRANSFER, internalAccount => DoDisplayNewTransfer(internalAccount));
            Register<InternalAccount>(App.Messages.CLOSE_TRANSACTION, account => DoCloseNewTransfer(account));
            Register<InternalAccount>(App.Messages.ACCOUNT_DELETED, account => DoCloseAccountDetail(account));
        }

        private void DoCloseNewTransfer(InternalAccount internalAccount)
        {
            string tag = "New Transfer";
            var tab = tabControl.FindByTag(tag);
            if (tab != null)
                tabControl.Items.Remove(tab);
        }

        private void DoCloseAccountDetail(InternalAccount internalAccount)
        {
            string tag = internalAccount.Iban;
            var tab = tabControl.FindByTag(tag);
            if (tab != null)
                tabControl.Items.Remove(tab);
        }

        private void DoDisplayInternalAccount(InternalAccount internalAccount)
        {
            if (internalAccount != null)
                OpenTab(internalAccount.Iban, internalAccount.Iban, () => new AccountDetailView(internalAccount));
        }

        private void DoDisplayNewTransfer(InternalAccount internalAccount)
        {
            if (internalAccount != null)
                OpenTab("New Transfer", "New Transfer", () => new NewTransferView(internalAccount));
        }

        private void OpenTab(string header, string tag, Func<UserControlBase> createView)
        {
            var tab = tabControl.FindByTag(tag);
            if (tab == null)
                tabControl.Add(createView(), header, tag);
            else
                tabControl.SetFocus(tab);
        }
        private void MenuLogout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NotifyColleagues(App.Messages.MSG_LOGOUT);
        }
    }
}
