using MoneyInTheBank.ViewModel;
using Newtonsoft.Json;
using PRBD_Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MoneyInTheBank.Model
{
    public class Transaction : EntityBase<MoneyInTheBankContext>
    {
        [Key]
        public long TransactionId { get; set; }
        [Required]
        public virtual User Principal { get; set; }
        [Required]
        public double Amount { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        public DateTime ActionDateTime { get; set; }
        [Required]
        public virtual Account Source { get; set; }
        [Required]
        public virtual Account Recipient { get; set; }
        public virtual Category Category { get; set; }
        //[NotMapped]
        //public double TemporaryBalance { get; set; }

        //[NotMapped]
        //public double AmountToDisplay { get; set; }

        [NotMapped]
        public Status TransactionStatus { get; set; }
        public Transaction()
        {
        }

        public Transaction(Client principal, double amount, InternalAccount source, Account recipient, DateTime creationDateTime, string description, Category category = null, DateTime? actionDateTime = null)
        {
            Principal = principal;
            Amount = amount;
            Description = description;
            CreationDateTime = creationDateTime;
            ActionDateTime = actionDateTime ?? CreationDateTime;
            Source = source;
            Recipient = recipient;
            Category = category;
        }

        public Transaction(User principal, double amount, ExternalAccount source, Account recipient, DateTime creationDateTime, string description, Category category = null, DateTime? actionDateTime = null)
        {
            Principal = principal;
            Amount = amount;
            Description = description;
            CreationDateTime = creationDateTime;
            ActionDateTime = actionDateTime ?? CreationDateTime;
            Source = source;
            Recipient = recipient;
            Category = category;
        }

        public static IQueryable<Transaction> GetAll()
        {
            return Context.Transactions.OrderBy(t => t.ActionDateTime).ThenBy(t => t.CreationDateTime);
        }

        public static IQueryable<Transaction> GetAllByAccount(InternalAccount internalAccount)
        {
            var query = from t in Context.Transactions                                                                                                                                                                  
                        where t.Source == internalAccount || t.Recipient == internalAccount
                        orderby t.ActionDateTime
                        select t;
            return query;
        }

        public static IQueryable<Transaction> GetFiltered(string Filter)
        {
            var filtered = from t in Context.Transactions
                           where t.Source.Iban.Contains(Filter) || t.Recipient.Iban.Contains(Filter) || t.Description.Contains(Filter) || t.Amount.ToString().Contains(Filter)
                           orderby t.ActionDateTime
                           select t;
            return filtered;
        }

        public static IQueryable<Transaction> GetFilteredByAccount(InternalAccount internalAccount, string Filter)
        {
            var filtered = from t in Context.Transactions
                           where (t.Source.Iban.Contains(Filter) || t.Recipient.Iban.Contains(Filter) || t.Description.Contains(Filter) || t.Amount.ToString().Contains(Filter)) && t.Source == internalAccount || t.Recipient == internalAccount
                           orderby t.ActionDateTime
                           select t;
            return filtered;
        }

        public static void ComputeBalance(IQueryable<Transaction> transactions, DateTime CurrentDateTime)
        {
            InternalAccount.ResetBalanceAccounts();
            foreach (var t in transactions)
            {
                if (t.CreationDateTime > CurrentDateTime)
                    t.TransactionStatus = Status.NOT_DISPLAYED;
                else if (t.ActionDateTime > CurrentDateTime)
                    t.TransactionStatus = Status.NOT_EXECUTED;
                else if (t.ActionDateTime <= CurrentDateTime)
                {
                     if (t.Source is ExternalAccount)
                    {
                        ((InternalAccount)t.Recipient).Balance += t.Amount;
                        t.TransactionStatus = Status.EXECUTED;
                    }
                    else
                    {
                        InternalAccount Source = (InternalAccount)t.Source;
                        if (Source.Balance - t.Amount >= Source.LowerLimit)
                        {
                            Source.Balance -= t.Amount;
                            t.TransactionStatus = Status.EXECUTED;
                            if (t.Recipient is InternalAccount)
                            {
                                InternalAccount Recipient = (InternalAccount)t.Recipient;
                                Recipient.Balance += t.Amount;
                            }
                        }
                        else
                        {
                            t.TransactionStatus = Status.REFUSED;
                        }
                    }
                }
            }
        }

        public void Add()
        {
            Context.Transactions.Add(this);
            Context.SaveChanges();
        }

        public void Delete()
        {
            Context.Transactions.Remove(this);
            Context.SaveChanges();
        }
    }
}
