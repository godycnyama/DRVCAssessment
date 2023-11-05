namespace Roulette.Application.Exceptions;
public class SpinNotFoundException : Exception
{
    public SpinNotFoundException()
    {
    }

    public SpinNotFoundException(string message)
        : base(message)
    {
    }

    public SpinNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}