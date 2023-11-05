namespace Roulette.Application.Exceptions;
public class AccountNotFoundException : Exception
{
    public AccountNotFoundException()
    {
    }

    public AccountNotFoundException(string message)
        : base($"Account with id: {message} not found")
    {
    }

    public AccountNotFoundException(string message, Exception inner)
        : base($"Account with id: {message} not found", inner)
    {
    }
}