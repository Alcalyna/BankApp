using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


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
    }
}
