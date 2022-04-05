namespace Pikachu;

public class ServiceProvider
{
    private readonly Dictionary<Type, Func<object>> _transientTypes = new();
    private readonly Dictionary<Type, Lazy<object>> _singletonTypes = new();
    internal ServiceProvider(ServiceCollection serviceCollection)
    {
        GenerateServices(serviceCollection);
    }

    public T? GetService<T>()
    {
        return (T?) GetService(typeof(T));
    }
    
    public object? GetService(Type serviceType)
    {
        var service = _singletonTypes.GetValueOrDefault(serviceType);

        if (service is not null)
            return service.Value;

        var transientService = _transientTypes.GetValueOrDefault(serviceType);
        return transientService?.Invoke();
    }
    
    private void GenerateServices(ServiceCollection serviceCollection)
    {
        foreach (var serviceDescriptor in serviceCollection)
        {
            switch (serviceDescriptor.LifeTime)
            {
                case ServiceLifetime.Singleton:
                    if (serviceDescriptor.Implementation is not null)
                    {
                        _singletonTypes[serviceDescriptor.ServiceType] =
                            new Lazy<object>(serviceDescriptor.Implementation);
                        continue;
                    }

                    var check = this;

                    if (serviceDescriptor.ImplementationFactory is not null)
                    {
                        _singletonTypes[serviceDescriptor.ServiceType] =
                            new Lazy<object>(() => serviceDescriptor.ImplementationFactory(this));
                        continue;
                    }
                    
                    _singletonTypes[serviceDescriptor.ServiceType] =
                        new Lazy<object>(() =>
                            Activator.CreateInstance(serviceDescriptor.ImplementaionType,
                            GetConstructorParameters(serviceDescriptor))!);
                    continue;
                case ServiceLifetime.Transient:
                    if (serviceDescriptor.ImplementationFactory is not null)
                    {
                        _transientTypes[serviceDescriptor.ServiceType] =
                            () => serviceDescriptor.ImplementationFactory(this);
                        continue;
                    }
                    
                    _transientTypes[serviceDescriptor.ServiceType] = () =>
                        Activator.CreateInstance(serviceDescriptor.ImplementaionType,
                            GetConstructorParameters(serviceDescriptor))!;
                    continue;
                
            }
        }
        
    }

    private object?[] GetConstructorParameters(ServiceDescriptor descriptor)
    {
        var constructorInfo = descriptor.ImplementaionType.GetConstructors().First();
        var parameters = constructorInfo.GetParameters()
            .Select(x => GetService(x.ParameterType)).ToArray();

        return parameters;
    }
}