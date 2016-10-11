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
        public void SetTile()
        {

            Display("******-----Welcome to Dakkada Bank ---------*****");
            Display("-----Automated Teller Machine ---------");

        }


        public void Display(string info)
        {
            Console.WriteLine(String.Format("       {0}", info));
            Console.WriteLine();
            
        }

        public void Wait()
        {
            Console.ReadLine();
        }


        public void Clear()
        {
            Console.Clear();
            SetTile();
        }
    }
}
