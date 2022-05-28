using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MoneyInTheBank.Model
{
    public class Agency
    {
        [Key]
        public long AgencyId { get; set; }
        [Required]
        public string Name { get; set; }
        public long ManagerId { get; set; }
        [Required]
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Client> Clients { get; set; } = new HashSet<Client>(); 
        public Agency() { }

        public List<Client> GetAllClients()
        {
            return Clients.ToList();
        }

    }
}
