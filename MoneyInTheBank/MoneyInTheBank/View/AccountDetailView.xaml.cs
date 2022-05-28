using MoneyInTheBank.Model;
using PRBD_Framework;

namespace MoneyInTheBank.View
{
    public partial class AccountDetailView : UserControlBase
    {
        public AccountDetailView(InternalAccount internalAccount)
        {
            InitializeComponent();
            vm.Init(internalAccount);
        }

    }
}
