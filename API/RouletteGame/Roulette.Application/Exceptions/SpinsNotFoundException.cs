namespace Roulette.Application.Exceptions;
public class SpinsNotFoundException : Exception
{
    public SpinsNotFoundException()
    {
    }

    public SpinsNotFoundException(string message = "No spin records found")
        : base(message)
    {
    }

    public SpinsNotFoundException(Exception inner, string message = "No spin records found")
        : base(message, inner)
    {
    }
}