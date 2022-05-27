using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoneyInTheBank.Model
{
    public class CheckingAccount: InternalAccount
    {
        public virtual ICollection<ClientCheckingAccount> Clients { get; set; } = new HashSet<ClientCheckingAccount>();

        public IQueryable<Account> GetAllOwnRecipients(Client client)
        {
            var query = from cia in Context.ClientInternalAccounts
                        where cia.Client == client && cia.InternalAccount != this
                        select cia.InternalAccount;
            return query;
        }

        public IQueryable<Account> GetAllOtherRecipients(Client client)
        {
            var query1 = from cia in Context.ClientInternalAccounts
                         where cia.Client.UserId != client.UserId
                         select cia.InternalAccount;

            var query2 = from cia in Context.ClientInternalAccounts
                         where cia.Client.UserId == client.UserId
                         select cia.InternalAccount;

            var query3 = from e in Context.ExternalAccounts
                         select e;

            List<Account> list1 = new List<Account>(query1);
            List<Account> list2 = new List<Account>(query2);
            List<Account> all = list1.Except(list2).ToList();
            List<Account> list3 = new List<Account>(query3);
            all.AddRange(list3);

            return all.AsQueryable();
        }

        public IQueryable<Account> GetAllRecipients(Client client)
        {
            List<Account> list1 = new List<Account>(GetAllOwnRecipients(client));
            List<Account> list2 = new List<Account>(GetAllOtherRecipients(client));
            list1.AddRange(list2);
            return list1.AsQueryable();
        }

        public IQueryable<Account> GetAllOwnRecipientsFiltered(string Filter, Client client)
        {
            var filtered = from ia in GetAllOwnRecipients(client)
                           where ia.Iban.Contains(Filter) || ia.Description.Contains(Filter)
                           orderby ia.Iban
                           select ia;
            return filtered;
        }

        public IQueryable<Account> GetAllOtherRecipientsFiltered(string Filter, Client client)
        {
            var filtered = from ia in GetAllOtherRecipients(client)
                           where ia.Iban.Contains(Filter) || ia.Description.Contains(Filter)
                           orderby ia.Iban
                           select ia;
            return filtered;
        }
    }
}
