namespace Pikachu;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceCollection AddSingleton<TService, TImplementation>()
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddTransient<TService, TImplementation>()
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Transient);
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider(this);
    }
    
    private static ServiceDescriptor AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime lifetime)
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementaionType = typeof(TImplementation),
            LifeTime = lifetime
        };
        return serviceDescriptor;
    }
}