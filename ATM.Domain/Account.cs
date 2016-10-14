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
        public string PhoneNos { get; set; }

        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public string StateOfOrigin { get; set; }
        public Gender Gender { get; set; }

        public byte[] Passport { get; set; }

        public byte[] Signature { get; set; }

    }


    public enum AccountType
    {
        Savings,
        Current
    }
}
