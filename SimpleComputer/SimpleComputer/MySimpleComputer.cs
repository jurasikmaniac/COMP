using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleComputer
{
    class MySimpleComputer
    {
        public int MemSize{get;set;}
        
        public MyMemory memory;

        public MySimpleComputer(int _m)
        {
            MemSize = _m;
            memory = new MyMemory(_m);
            // TODO: Complete member initialization
        }
    }
}
