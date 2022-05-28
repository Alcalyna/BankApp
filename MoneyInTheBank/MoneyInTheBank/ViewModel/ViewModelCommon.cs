using MoneyInTheBank.Model;
using PRBD_Framework;
using System;

namespace MoneyInTheBank.ViewModel
{
    public abstract class ViewModelCommon : ViewModelBase<User, MoneyInTheBankContext>
    {
        public static bool IsAdmin => App.IsLoggedIn && App.CurrentUser is Admin;
        public static bool IsClient => App.IsLoggedIn && App.CurrentUser is Client;
        public static bool IsManager => App.IsLoggedIn && App.CurrentUser is Manager;


        public static bool IsNotAdmin => !IsAdmin;
    
    
        public Client GetCurrentClient()
        {
            if(IsClient)
                return (Client)App.CurrentUser;
            else
                return null;
        }

        public Manager GetCurrentManager()
        {
            if (IsManager)
                return (Manager)App.CurrentUser;
            else
                return null;
        }
        public Admin GetCurrentAdmin()
        {
            if (IsAdmin)
                return (Admin)App.CurrentUser;
            else
                return null;
        }
        public static DateTime CurrentDate { get; set; }

    }


}
