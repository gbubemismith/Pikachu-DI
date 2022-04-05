namespace Pikachu;

public class ServiceCollection : List<ServiceDescriptor>
{
    public ServiceCollection AddService(ServiceDescriptor descriptor)
    {
        Add(descriptor);
        return this;
    }

    public ServiceCollection AddSingleton<TService>(Func<ServiceProvider, TService> factory) where TService : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementaionType = typeof(TService),
            ImplementationFactory = factory,
            LifeTime = ServiceLifetime.Singleton
        };
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddTransient<TService>(Func<ServiceProvider, TService> factory) where TService : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementaionType = typeof(TService),
            ImplementationFactory = factory,
            LifeTime = ServiceLifetime.Transient
        };
        Add(serviceDescriptor);
        return this;
    }

    public ServiceCollection AddSingleton(object implementation)
    {
        var serviceType = implementation.GetType();
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = serviceType,
            ImplementaionType = serviceType,
            Implementation = implementation,
            LifeTime = ServiceLifetime.Singleton
        };
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddSingleton<TService>() where TService : class 
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TService>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddTransient<TService>() where TService : class
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TService>(ServiceLifetime.Transient);
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddSingleton<TService, TImplementation>() where TService : class where TImplementation : class, TService
    {
        var serviceDescriptor = AddServiceDescriptorWithLifetime<TService, TImplementation>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);
        return this;
    }
    
    public ServiceCollection AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
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