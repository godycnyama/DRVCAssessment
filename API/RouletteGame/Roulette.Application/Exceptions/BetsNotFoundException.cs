namespace Roulette.Application.Exceptions;
public class BetsNotFoundException : Exception
{
    public BetsNotFoundException()
    {
    }

    public BetsNotFoundException(string message)
        : base(message)
    {
    }

    public BetsNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}