using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIOCContainer
{

    public interface IWriter
    {
        void Write(string s);
    }

    public class ConsoleWriter : IWriter
    {

        public ConsoleWriter() {
            Console.WriteLine("ConsoleWriter Constructor invoked");
        }

        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
