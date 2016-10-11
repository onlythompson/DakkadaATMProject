using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTesting
{
    public class ConsoleInput : IKeypad
    {
        
        public int getInput()
        {
            return Convert.ToInt32(Console.ReadLine());

            //Method 2
            //String input = Console.ReadLine();
            //int data;
            //if (int.TryParse(input, out data))
            //{
            //    return data;
            //}

        }
    }
}
