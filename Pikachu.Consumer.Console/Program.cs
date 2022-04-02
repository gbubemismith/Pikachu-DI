
using Pikachu;
using Pikachu.Consumer.Console;

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetService<IConsoleWriter>();