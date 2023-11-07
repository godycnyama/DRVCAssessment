namespace Roulette.Application.Exceptions;
public class SessionNotFoundException : Exception
{
    public SessionNotFoundException()
    {
    }

    public SessionNotFoundException(string message)
        : base($"Session with id: {message} not found")
    {
    }

    public SessionNotFoundException(string message, Exception inner)
        : base($"Session with id: {message} not found", inner)
    {
    }
}