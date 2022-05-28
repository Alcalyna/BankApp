using MoneyInTheBank.Model;
using PRBD_Framework;

namespace MoneyInTheBank.View
{
    public partial class RecipientsView : DialogWindowBase
    {

        public RecipientsView(InternalAccount internalAccount)
        {
            InitializeComponent();
            vm.CurrentInternalAccount = internalAccount;
        }

        private void DialogWindowBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (vm.DialogResult == null)
                e.Cancel = true;
        }
    }
}
