using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public interface IScreen
    {
        void Display(string info);
        void Wait();
        void Clear();
    }
}
