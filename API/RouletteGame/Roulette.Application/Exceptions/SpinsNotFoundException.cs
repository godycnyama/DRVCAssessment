namespace Roulette.Application.Exceptions;
public class SpinsNotFoundException : Exception
{
    public SpinsNotFoundException()
    {
    }

    public SpinsNotFoundException(string message)
        : base(message)
    {
    }

    public SpinsNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}