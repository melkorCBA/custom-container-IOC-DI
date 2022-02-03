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
        private readonly IWelcomer _welcomer;

        public Greeter(IWriter writer, IWelcomer welcomer)
        {
            this.writer = writer;
            _welcomer = welcomer;
        }

        public void SayHelloTo(string name)
        {
            _welcomer.SayHelloTo("world");
            writer.Write($"Hello from greeter {name}!");

        }
    }
}
