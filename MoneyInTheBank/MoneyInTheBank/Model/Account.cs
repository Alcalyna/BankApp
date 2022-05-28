using PRBD_Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MoneyInTheBank.Model
{
    public abstract class Account : EntityBase<MoneyInTheBankContext>
    {
        [Key]
        public long AccountId { get; set; }
        public string Iban { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Transaction> TransactionsIn { get; set; } = new HashSet<Transaction>();
        public virtual ICollection<Transaction> TransactionsOut { get; set; } = new HashSet<Transaction>();

        public Account() { }

        public static Account GetByIban(string iban)
        {
            return Context.Accounts.SingleOrDefault(a => a.Iban.ToUpper().Replace(" ", "") == iban.ToUpper().Replace(" ", ""));
        }

        public void Add()
        {
            Context.Accounts.Add(this);
            Context.SaveChanges();
        }

        public void Delete()
        {
            Context.Accounts.Remove(this);
            Context.SaveChanges();
        }
    }
}
