using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Domain
{
    public class WithdrawalTransaction : Transaction
    {
        public decimal Amount { get; set; }


    }
}
