namespace Pikachu;

public class ServiceProvider
{
    public T? GetService<T>()
    {
        return (T?) GetService(typeof(T));
    }
    
    public object? GetService(Type serviceType)
    {
        throw new NotImplementedException();
    }
}