namespace Pikachu.Consumer.Console;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string text)
    {
        System.Console.WriteLine(text);
    }
}

public interface IConsoleWriter
{
    void WriteLine(string text);
}