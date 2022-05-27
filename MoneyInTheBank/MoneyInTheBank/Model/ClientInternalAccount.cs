using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;
using System.ComponentModel;

namespace MoneyInTheBank.Model
{
    public class ClientInternalAccount : EntityBase<MoneyInTheBankContext>
    {
        public long ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        
        public long InternalAccountId   { get; set; }
        [Required]
        public virtual InternalAccount InternalAccount { get; set; }

        public ClientInternalAccount() { }

        public RelationType Relation { get; set; }

        public enum RelationType
        {
            OWNER,
            PROXY
        }

        public static List<RelationType> GetAllRelationTypes()
        {
            List<RelationType> relationTypes = new List<RelationType>();
            foreach(RelationType relation in Enum.GetValues(typeof(RelationType)))
            {
                relationTypes.Add(relation);
            }
            return relationTypes;
        }

        public static ClientInternalAccount GetByClientAndInternalAccount(Client client, InternalAccount internalAccount)
        {
            return Context.ClientInternalAccounts.Single(cia => cia.InternalAccount == internalAccount && cia.Client == client);
        }

        public void Delete()
        {
            Context.ClientInternalAccounts.Remove(this);
            Context.SaveChanges();
        }

        public void Add()
        {
            Context.ClientInternalAccounts.Add(this);
            Context.SaveChanges();
        }
    }
}
