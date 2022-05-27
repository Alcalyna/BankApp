using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;
using System.ComponentModel;

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
    }
}
