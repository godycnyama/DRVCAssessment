namespace Roulette.Application.Exceptions;
public class BetNotFoundException : Exception
{
    public BetNotFoundException()
    {
    }

    public BetNotFoundException(string message)
        : base($"Bet with id: {message} not found")
    {
    }

    public BetNotFoundException(string message, Exception inner)
        : base($"Bet with id: {message} not found", inner)
    {
    }
}