namespace Roulette.Application.Exceptions;
public class AccountsNotFoundException : Exception
{
    public AccountsNotFoundException()
    {
    }

    public AccountsNotFoundException(string message)
        : base(message)
    {
    }

    public AccountsNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}