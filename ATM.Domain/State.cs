using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public class State
    {

        public State(string code, string name)
        {
            this.Name = name;
            this.Code = code;

        }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
