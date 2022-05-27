using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoneyInTheBank.Model
{
    public class Category : EntityBase<MoneyInTheBankContext>
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public Category() { }

        public Category(string Name)
        {
            this.Name = Name;
        }

        public static IQueryable<Category> GetAll()
        {
            return Context.Categories.OrderBy(c => c.Name);
        }

        public static IQueryable<string> GetAllNames()
        {
            var query = from c in Context.Categories
                        select c.Name;
            return query;
        }

        public static Category GetByName(string name)
        {
            return Context.Categories.SingleOrDefault(c => c.Name == name);
        }
    }
}

