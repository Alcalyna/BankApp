using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;


namespace MoneyInTheBank.Model
{
    public abstract class User: EntityBase<MoneyInTheBankContext>
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public User() { }

        public static User GetByEmail(string email)
        {
            return Context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
