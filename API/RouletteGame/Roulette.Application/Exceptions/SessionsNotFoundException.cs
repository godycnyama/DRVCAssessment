namespace Roulette.Application.Exceptions;
public class SessionsNotFoundException : Exception
{
    public SessionsNotFoundException()
    {
    }

    public SessionsNotFoundException(string message = "No spin records found")
        : base(message)
    {
    }

    public SessionsNotFoundException(Exception inner, string message = "No spin records found")
        : base(message, inner)
    {
    }
}