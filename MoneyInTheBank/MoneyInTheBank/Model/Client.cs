using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace MoneyInTheBank.Model
{
    public class Client: User
    {
        [Required]
        public string ClientNumber { get; set; }
        
        public long AgencyId { get; set; }
        [Required]
        public virtual Agency Agency { get; set; }

        public virtual ICollection<ClientInternalAccount> ClientInternalAccounts { get; set; } = new HashSet<ClientInternalAccount>();

        public List<InternalAccount> GetAllAccountsExcept(InternalAccount internalAccount)
        {
            var query = from ia in Context.InternalAccounts
                        where ia.ClientInternalAccounts.Any(cia => cia.Client == this) && ia != internalAccount
                        orderby ia.Iban
                        select ia;
            return new List<InternalAccount>(query);
        }

        public List<InternalAccount> GetAllAccounts()
        {
            var query = from i in Context.InternalAccounts
                        where i.ClientInternalAccounts.Any(x => x.Client == this)
                        orderby i.Iban
                        select i;
            return new List<InternalAccount>(query);
        }

        public IQueryable<InternalAccount> GetInternalAccounts()
        {
            var query = from cia in Context.ClientInternalAccounts
                        where cia.Client == this
                        select cia.InternalAccount;
            return query;
        }

        public List<InternalAccount> GetOtherInternalAccounts()
        {
            var query1 = from cia in Context.ClientInternalAccounts
                         where cia.Client.UserId != this.UserId
                         select cia.InternalAccount;

            var query2 = from cia in Context.ClientInternalAccounts
                         where cia.Client.UserId == this.UserId
                         select cia.InternalAccount;
            List<InternalAccount> list1 = new List<InternalAccount>(query1);
            List<InternalAccount> list2 = new List<InternalAccount>(query2);
            List<InternalAccount> diff = list1.Except(list2).OrderBy(ia => ia.Iban).ToList();
            return diff;
        }

        public static void SetClientNumber()
        {
            Client client = Context.Clients.SingleOrDefault(c => c.ClientNumber == "0000");
            client.ClientNumber = client.UserId.ToString().PadLeft(4, '0');
        }

        public void Delete()
        {
            Context.Clients.Remove(this);
            Context.SaveChanges();
        }

        public void Add()
        {
            Context.Clients.Add(this);
            Context.SaveChanges();
        }

    }
}
