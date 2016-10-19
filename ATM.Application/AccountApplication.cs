using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application
{
    public class AccountApplication
    {

        IList<Account> Accounts;

        public AccountApplication()
        {
            Accounts = new List<Account>();
        }
        public void SaveAccount(Domain.Account account)
        {
            try
            {
                Accounts.Add(account);

            }
            catch (Exception)
            {
                
                throw;
            }
        }




    }
}
