// See https://aka.ms/new-console-template for more information
using CustomIOCContainer;

var container = new CustomContainer();

container.AddTransient<IWelcomer, Welcomer>();
container.AddTransient<IGreeter, Greeter>();
container.AddSingelton<IWriter, ConsoleWriter>();


var welcomer = container.GetService<IWelcomer>();

welcomer.SayHelloTo("World");
var greeter = container.GetService<IGreeter>();
greeter.SayHelloTo("World");