namespace Pikachu;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider();
    }
}