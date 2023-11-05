namespace Roulette.Application.Exceptions;
public class PayoutsNotFoundException : Exception
{
    public PayoutsNotFoundException()
    {
    }

    public PayoutsNotFoundException(string message = "No payout records found")
        : base(message)
    {
    }

    public PayoutsNotFoundException(Exception inner, string message = "No payout records found")
        : base(message, inner)
    {
    }
}