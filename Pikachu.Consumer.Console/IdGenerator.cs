namespace Pikachu.Consumer.Console;

public class IdGenerator : IIdGenrator
{
    public Guid Id { get; } = Guid.NewGuid();
}

public interface IIdGenrator
{
    public Guid Id { get; }
}