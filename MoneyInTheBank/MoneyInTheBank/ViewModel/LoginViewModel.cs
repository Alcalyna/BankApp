using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using MoneyInTheBank.Model;
using System.Text.RegularExpressions;
using System.Windows.Input;
using MoneyInTheBank.View;

namespace MoneyInTheBank.ViewModel
{
    public class LoginViewModel : ViewModelCommon
    {
        public ICommand LoginCommand { get; set; }

        //private string _email = "linh@moneyinthebank.com";
        //private string _email = "ben@test.com";
        private string _email = "bob@test.com";
        //private string _email = "admin@test.com";
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, () => Validate());
        }

        //private string _password = "linh";
        //private string _password = "ben";
        private string _password = "bob";
        //private string _password = "admin";
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, () => Validate());
        }

        public LoginViewModel() : base()
        {
            LoginCommand = new RelayCommand(LoginAction,
                () => { return _email != null && _password != null && !HasErrors; });
        }

        private void LoginAction()
        {
            if (Validate())
            {
                var user = User.GetByEmail(Email);
                NotifyColleagues(App.Messages.MSG_LOGIN, user);
            }
        }

        public override bool Validate()
        {
            ClearErrors();

            var user = User.GetByEmail(Email);

            if (string.IsNullOrEmpty(Email))
                AddError(nameof(Email), "required");
            else if (Email.Length < 3)
                AddError(nameof(Email), "length must be >= 3");
            else if (user == null)
                AddError(nameof(Email), "does not exist");
            else
            {
                if (string.IsNullOrEmpty(Password))
                    AddError(nameof(Password), "required");
                else if (Password.Length < 3)
                    AddError(nameof(Password), "length must be >= 3");
                else if (user != null && user.Password != Password)
                    AddError(nameof(Password), "wrong password");
            }

            return !HasErrors;
        }
    }
}
