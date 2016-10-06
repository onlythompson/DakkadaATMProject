using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTesting
{
    public class ConsoleKeypad : IKeypad
    {
        public int getNumberInput()
        {
            try
            {  

                String input = Console.ReadLine();

                return Convert.ToInt32(input);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }


        public String getStringInput()
        {
            return Console.ReadLine();
        }
    }
}
