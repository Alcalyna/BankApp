using System.Linq;

namespace MoneyInTheBank.Model
{
    public class ExternalAccount: Account
    {
        public static IQueryable<ExternalAccount> GetAll()
        {
            return Context.ExternalAccounts.OrderBy(ea => ea.Iban);
        }

        public static IQueryable<string> GetAllIbans()
        {
            var query = from account in Context.ExternalAccounts
                        select account.Iban;
            return query;
        }
    }
}
