namespace Roulette.Application.Exceptions;
public class PayoutNotFoundException : Exception
{
    public PayoutNotFoundException()
    {
    }

    public PayoutNotFoundException(string message)
        : base(message)
    {
    }

    public PayoutNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}