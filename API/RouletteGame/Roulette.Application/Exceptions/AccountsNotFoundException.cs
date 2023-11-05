namespace Roulette.Application.Exceptions;
public class AccountsNotFoundException : Exception
{
    public AccountsNotFoundException()
    {
    }

    public AccountsNotFoundException(string message = "No account records found")
        : base(message)
    {
    }

    public AccountsNotFoundException(Exception inner, string message = "No account records found")
        : base(message, inner)
    {
    }
}