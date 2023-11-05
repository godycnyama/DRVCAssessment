namespace Roulette.Application.Exceptions;
public class BetNotFoundException : Exception
{
    public BetNotFoundException()
    {
    }

    public BetNotFoundException(string message)
        : base(message)
    {
    }

    public BetNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}