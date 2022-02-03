// See https://aka.ms/new-console-template for more information
using CustomIOCContainer;

var container = new CustomContainer();

container.AddSingelton<IWelcomer, Welcomer>();
container.AddSingelton<IWriter, ConsoleWriter>();
container.AddTransient<IGreeter, Greeter>();



var greeter = container.GetService<IGreeter>();
greeter.SayHelloTo("World");