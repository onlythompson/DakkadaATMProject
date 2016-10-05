using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public class Customer
    {
        public string BVN { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string  Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }

    }


    public enum Gender
    {
        Male,
        Female
    }
}
