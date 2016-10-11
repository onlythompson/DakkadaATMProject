using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public class Account
    {
        public string AccountNos { get; set; }
        public string BVN { get; set; }
        public AccountType TypeofAccount { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public decimal TransactionLimit { get; set; }

    }


    public enum AccountType
    {
        Savings,
        Current
    }
}
