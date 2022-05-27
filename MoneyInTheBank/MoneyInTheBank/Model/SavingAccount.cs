using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MoneyInTheBank.Model
{
    public class SavingAccount: InternalAccount
    {
        public SavingAccount() 
        {
            this.LowerLimit = 0;
        }

        public virtual ICollection<ClientSavingAccount> Clients { get; set; } = new HashSet<ClientSavingAccount>();

        public IQueryable<Account> GetAllRecipients(Client client)
        {
            var query = from cia in Context.ClientCheckingAccounts
                        where cia.Client == client && cia.InternalAccount is CheckingAccount
                        select cia.InternalAccount;

            return query;
        }

        public IQueryable<Account> GetAllRecipientsFiltered(string Filter, Client client)
        {
            var query = from ia in GetAllRecipients(client)
                        where ia.Iban.Contains(Filter) || ia.Description.Contains(Filter)
                        orderby ia.Iban
                        select ia;
            return query;
        }
    }
}
