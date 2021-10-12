using System;
using System.Collections.Generic;
using System.Text;

namespace SPP2.Writing
{
    class ConsoleWriter : IWriter
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
