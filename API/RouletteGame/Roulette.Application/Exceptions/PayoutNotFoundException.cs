namespace Roulette.Application.Exceptions;
public class PayoutNotFoundException : Exception
{
    public PayoutNotFoundException()
    {
    }

    public PayoutNotFoundException(string message)
        : base($"Payout with id: {message} not found")
    {
    }

    public PayoutNotFoundException(string message, Exception inner)
        : base($"Payout with id: {message} not found", inner)
    {
    }
}