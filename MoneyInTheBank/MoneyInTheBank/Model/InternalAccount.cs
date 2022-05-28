using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static MoneyInTheBank.Model.ClientInternalAccount;

namespace MoneyInTheBank.Model
{
    public abstract class InternalAccount: Account
    {
        [Required]
        public double LowerLimit { get; set; }
        public virtual ICollection<ClientInternalAccount> ClientInternalAccounts { get; set; } = new HashSet<ClientInternalAccount>();
        [NotMapped]
        public double Balance { get; set; }

        [NotMapped]
        public double TemporaryBalance { get; set; }
        [NotMapped]
        public RelationType Relation { get; set; }
        [NotMapped]
        public string Type { get; set; }
        public RelationType GetRelationType(Client client) => ClientInternalAccounts.SingleOrDefault(c => c.Client == client && c.InternalAccount == this).Relation;
        public static IQueryable<InternalAccount> GetAll() => Context.InternalAccounts.OrderBy(ia => ia.Iban);
        public static IQueryable<InternalAccount> GetFiltered(string Filter)
        {
            var filtered = from ia in Context.InternalAccounts
                           where ia.Iban.Contains(Filter) || ia.Description.Contains(Filter)
                           orderby ia.Iban
                           select ia;
            return filtered;
        }

        public int GetNumberOfOwners()
        {
            var query = from cia in Context.ClientInternalAccounts
                        where cia.InternalAccount == this && cia.Relation == RelationType.OWNER
                        select cia;
            int numberOfOwners = query.Count();
            return numberOfOwners;
        }

        public bool IsSolvent(double amount) => this.Balance - amount < this.LowerLimit;

        public double GetMaxAmount() => this.Balance - this.LowerLimit;

        public static void ResetBalanceAccounts()
        {
            var query = from a in Context.InternalAccounts
                        select a;
            foreach (var a in query)
                a.Balance = 0;
        }

        public static void ResetTemporaryBalanceAccounts()
        {
            var query = from a in Context.InternalAccounts
                        select a;
            foreach (var a in query)
                a.TemporaryBalance = 0;
        }
    }
}
