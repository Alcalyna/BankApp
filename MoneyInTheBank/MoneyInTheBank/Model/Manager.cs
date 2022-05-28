using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyInTheBank.Model
{
    public class Manager: User
    {
        public virtual ICollection<Agency> Agencies { get; set; } = new HashSet<Agency>();

        public List<Agency> GetAllAgencies() => Agencies.ToList();
    }
}
