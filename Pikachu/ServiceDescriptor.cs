namespace Pikachu;

public class ServiceDescriptor
{
    public Type ServiceType { get; init; } = default!;
    public Type? ImplementaionType { get; set; }
    public object? Implementation { get; set; }
    public Func<ServiceProvider, object>? ImplementationFactory { get; set; }
    public ServiceLifetime LifeTime { get; set; }
}