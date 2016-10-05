using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Domain
{
    public class VirtualCardInfo
    {

        public string NameOnCard { get; set; }

        public string CardNo { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Bank_Name { get; set; }

        public bool HasExpired()
        {
            if (DateTime.Now < ExpiryDate)
            {
                return false;
            }

            return true;
        }


        public string  PIN { get; set; }
    }
}
