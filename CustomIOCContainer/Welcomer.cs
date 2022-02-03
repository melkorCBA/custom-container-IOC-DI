using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIOCContainer
{
    public interface IWelcomer
    {
        void SayHelloTo(string name);
    }

    public class Welcomer : IWelcomer
    {
        private IWriter writer;

        public Welcomer(IWriter writer)
        {
            this.writer = writer;
        }

        public void SayHelloTo(string name)
        {
            writer.Write($"Hello from welcomer {name}!");
        }
    }
}
