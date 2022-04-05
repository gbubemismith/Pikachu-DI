
using Pikachu;
using Pikachu.Consumer.Console;

var services = new ServiceCollection();

// services.AddTransient<IIdGenrator, IdGenerator>();
// services.AddTransient<ConsoleWriter>();
services.AddSingleton(provider => new IdGenerator());

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetService<IdGenerator>();
var service2 = serviceProvider.GetService<IdGenerator>();

Console.WriteLine(service.Id);
Console.WriteLine(service2.Id);