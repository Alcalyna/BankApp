using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using PRBD_Framework;
using MoneyInTheBank.Model;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

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
