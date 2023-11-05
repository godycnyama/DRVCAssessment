namespace Roulette.Application.Exceptions;
public class BetsNotFoundException : Exception
{
    public BetsNotFoundException()
    {
    }

    public BetsNotFoundException(string message = "No bet records found")
        : base(message)
    {
    }

    public BetsNotFoundException(Exception inner, string message = "No bet records found")
        : base(message, inner)
    {
    }
}