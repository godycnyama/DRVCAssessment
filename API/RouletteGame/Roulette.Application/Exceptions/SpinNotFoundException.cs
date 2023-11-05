namespace Roulette.Application.Exceptions;
public class SpinNotFoundException : Exception
{
    public SpinNotFoundException()
    {
    }

    public SpinNotFoundException(string message)
        : base($"Spin with id: {message} not found")
    {
    }

    public SpinNotFoundException(string message, Exception inner)
        : base($"Spin with id: {message} not found", inner)
    {
    }
}