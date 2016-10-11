using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTesting
{
    public class VictorsScreen : IScreen
    {
        public void Display(string info)
        {
            Console.WriteLine("This is victors screen");
            Console.WriteLine(info);
        }

        public void Wait()
        {
            Console.WriteLine("This is the foot of victors screen");
            Console.ReadLine();
        }


        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
