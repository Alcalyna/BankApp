using MoneyInTheBank.ViewModel;
using Newtonsoft.Json;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyInTheBank.Model
{
    public class Transaction : EntityBase<MoneyInTheBankContext>
    {
        [Key]
        public long TransactionId { get; set; }
        [Required]
        public virtual Client Principal { get; set; }
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
        [NotMapped]
        public double TemporaryBalance { get; set; }

        [NotMapped]
        public double AmountToDisplay { get; set; }

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

        public static void SetProperties(IQueryable<Transaction> transactions, DateTime CurrentDateTime, InternalAccount CurrentAccount)
        {
            ResetBalanceAccounts();
            foreach (var t in transactions)
            {
                ResetTransaction(t);
                if (t.CreationDateTime > CurrentDateTime)
                    t.TransactionStatus = Status.NOT_DISPLAYED;
                else if (t.ActionDateTime > CurrentDateTime)
                    ApplyNotExecuted(CurrentAccount, t);
                else
                {
                    if (t.Source is ExternalAccount)
                        ApplyExecutedFromExternalAccount(CurrentAccount, t);
                    else
                    {
                        InternalAccount Source = (InternalAccount)t.Source;
                        if (Source.Balance - t.Amount < Source.LowerLimit)
                            ApplyRefusedTransaction(CurrentAccount, t, Source);
                        else
                            ApplyExecutedFromInternalAccount(CurrentAccount, t, Source);
                    }
                }
            }
        }

        private static void ApplyExecutedFromInternalAccount(InternalAccount CurrentAccount, Transaction t, InternalAccount Source)
        {
            Source.Balance -= t.Amount;
            if (Source == CurrentAccount)
            {
                t.TemporaryBalance = Source.Balance;
                t.AmountToDisplay = t.Amount * -1;
            }
            if (t.Recipient is InternalAccount)
            {
                InternalAccount Recipient = (InternalAccount)t.Recipient;
                Recipient.Balance += t.Amount;
                t.TransactionStatus = Status.EXECUTED;
                if (Recipient == CurrentAccount)
                    t.TemporaryBalance = Recipient.Balance;
            }
        }

        private static void ApplyRefusedTransaction(InternalAccount CurrentAccount, Transaction t, InternalAccount Source)
        {
            t.TransactionStatus = Status.REFUSED;
            if (Source == CurrentAccount)
            {
                t.TemporaryBalance = Source.Balance;
                t.AmountToDisplay = t.Amount * -1;
            }
        }

        private static void ApplyExecutedFromExternalAccount(InternalAccount CurrentAccount, Transaction t)
        {
            ((InternalAccount)t.Recipient).Balance += t.Amount;

            if (((InternalAccount)t.Recipient) == CurrentAccount)
            {
                t.TemporaryBalance = ((InternalAccount)t.Recipient).Balance;
                t.TransactionStatus = Status.EXECUTED;
            }
        }

        private static void ApplyNotExecuted(InternalAccount CurrentAccount, Transaction t)
        {
            t.TransactionStatus = Status.NOT_EXECUTED;
            if (t.Source == CurrentAccount)
                t.AmountToDisplay = t.Amount * -1;
            else
                t.AmountToDisplay = t.Amount;
        }

        private static void ResetTransaction(Transaction t)
        {
            t.AmountToDisplay = t.Amount;
            t.TemporaryBalance = 0;
        }

        private static void ResetBalanceAccounts()
        {
            var query = from a in Context.InternalAccounts
                        select a;
            foreach (var a in query)
                a.Balance = 0;
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
