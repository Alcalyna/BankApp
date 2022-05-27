using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using static MoneyInTheBank.Model.ClientInternalAccount;
using System.Windows.Input;

namespace MoneyInTheBank.Model
{
    public abstract class InternalAccount: Account, INotifyPropertyChanged
    {
        [Required]
        public double LowerLimit { get; set; }
        public virtual ICollection<ClientInternalAccount> ClientInternalAccounts { get; set; } = new HashSet<ClientInternalAccount>();

        private double _balance;

        [NotMapped]
        public double Balance
        {
            get => _balance;
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    OnPropertyChanged("Balance");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string balance)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(balance));
        }
        [NotMapped]
        public RelationType Relation { get; set; }

        public RelationType GetRelationType(Client client)
        {
            return ClientInternalAccounts.SingleOrDefault(c => c.Client == client && c.InternalAccount == this).Relation;
        }
        [NotMapped]
        public string Type { get; set; }

        public static IQueryable<InternalAccount> GetAll()
        {
            return Context.InternalAccounts.OrderBy(ia => ia.Iban);
        }

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
            return query.Count();
        }
    }
}
