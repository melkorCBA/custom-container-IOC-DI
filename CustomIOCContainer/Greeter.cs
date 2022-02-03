using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIOCContainer
{
    public interface IGreeter
    {
        void SayHelloTo(string name);
    }

    public class Greeter : IGreeter
    {
        private IWriter writer;

        public Greeter(IWriter writer)
        {
            this.writer = writer;
        }

        public void SayHelloTo(string name)
        {
            writer.Write($"Hello from greeter {name}!");
        }
    }
}
