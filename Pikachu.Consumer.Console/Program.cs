
using Pikachu;

var services = new ServiceCollection();


var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetService<IConsoleWriter>();