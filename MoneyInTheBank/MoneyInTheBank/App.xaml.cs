using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRBD_Framework;
using MoneyInTheBank.Model;
using MoneyInTheBank.View;
using Microsoft.EntityFrameworkCore;
using MoneyInTheBank.ViewModel;
using System.Windows.Markup;
using System.Globalization;

namespace MoneyInTheBank
{
    public partial class App : ApplicationBase<User, MoneyInTheBankContext>
    {

        public enum Messages
        {
            MSG_NEW_MEMBER,
            MSG_PSEUDO_CHANGED,
            MSG_MEMBER_CHANGED,
            MSG_DISPLAY_MEMBER,
            MSG_CLOSE_TAB,
            MSG_LOGIN,
            MSG_REFRESH_MESSAGES,
            MSG_LOGOUT,
            DATE_CHANGED,
            INTERNAL_ACCOUNT_DETAIL,
            BALANCE_CHANGED,
            DISPLAY_INTERNAL_ACCOUNT,
            NEW_TRANSFER,
            SELECT_RECIPIENT,
            SET_RECIPIENT,
            NEW_TRANSACTION,
            TRANSACTION_CREATED,
            CLOSE_TRANSACTION,
            DISPLAY_CLIENT_PROFILE,
            CLIENT_UPDATED,
            CATEGORY_CHANGED,
            RECIPIENT_SELECTED,
            TRANSACTION_CANCELED,
            AGENCY_SELECTED,
            ADD_ACCOUNT_TO_USER,
            REMOVE_ACCOUNT_FROM_USER,
            ACCOUNT_DELETED
        }
        RecipientsView recipients { get; set; }
        RecipientsViewModel recipientsViewModel;
        protected override void OnStartup(StartupEventArgs e)
        {

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                    CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
            
            Context.SeedData();

            Register<User>(this, Messages.MSG_LOGIN, user => {
                Login(user);
                NavigateTo<MainViewModel, User, MoneyInTheBankContext>();
            });

            Register(this, Messages.MSG_LOGOUT, () => {
                Logout();
                NavigateTo<LoginViewModel, User, MoneyInTheBankContext>();
            });

        }

        protected override void OnRefreshData()
        {
            if (CurrentUser?.Email != null)
                CurrentUser = User.GetByEmail(CurrentUser.Email);
        }
    }
}
