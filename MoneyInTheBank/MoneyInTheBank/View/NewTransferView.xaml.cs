using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MoneyInTheBank.Model;
using PRBD_Framework;
using System.Windows;

namespace MoneyInTheBank.View
{
    public partial class NewTransferView : UserControlBase
    {
        public NewTransferView(InternalAccount internalAccount)
        {
            InitializeComponent();
            vm.Init(internalAccount);
        }
        private void amount_format(object sender, EventArgs e)
        {
            Double value;
            if (!Double.TryParse(amountInput.Text, out value))
                amountInput.Text = String.Empty;
            else
                amountInput.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
        }
    }
}
