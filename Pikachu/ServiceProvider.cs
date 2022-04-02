namespace Pikachu;

public class ServiceProvider
{
    private readonly Dictionary<Type, Func<object>> _transientTypes = new();
    private readonly Dictionary<Type, Func<object>> _singletonTypes = new();
    internal ServiceProvider(ServiceCollection serviceCollection)
    {
        
    }
    public T? GetService<T>()
    {
        return (T?) GetService(typeof(T));
    }
    
    public object? GetService(Type serviceType)
    {
        throw new NotImplementedException();
    }
}