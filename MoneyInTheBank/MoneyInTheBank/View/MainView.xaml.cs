using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.ComponentModel;

namespace MoneyInTheBank.View
{
    public partial class MainView : WindowBase
    {
        public MainView()
        {
            InitializeComponent();

            Register<InternalAccount>(App.Messages.DISPLAY_INTERNAL_ACCOUNT, internalAccount => DoDisplayInternalAccount(internalAccount));
            Register<InternalAccount>(App.Messages.NEW_TRANSFER, internalAccount => DoDisplayNewTransfer(internalAccount));
            Register<InternalAccount>(App.Messages.ACCOUNT_DELETED, account => DoCloseAccountDetail(account));
            Register(App.Messages.OPEN_NEW_TRANSACTION_ADMIN_TAB, () => DoDisplayNewTransferAdmin());
            Register(App.Messages.CLOSE_TRANSACTION, () => DoClose("New Transfer"));
            Register(App.Messages.CLOSE_NEW_TRANSACTION_ADMIN, () => DoClose("New Transfer admin"));
        }
        private void DoClose(string tag)
        {
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

        private void DoDisplayNewTransferAdmin()
        {
            OpenTab("New Transfer admin", "New Transfer admin", () => new AdminTransactionView());
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            tabControl.Dispose();
        }
    }
}
