namespace Roulette.Application.Exceptions;
public class PayoutsNotFoundException : Exception
{
    public PayoutsNotFoundException()
    {
    }

    public PayoutsNotFoundException(string message)
        : base(message)
    {
    }

    public PayoutsNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}