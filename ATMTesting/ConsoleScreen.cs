using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTesting
{
    public class ConsoleScreen : IScreen
    {
        public void Display(string info)
        {
            Console.WriteLine(info);
            
        }

        public void Wait()
        {
            Console.ReadLine();
        }
    }
}
