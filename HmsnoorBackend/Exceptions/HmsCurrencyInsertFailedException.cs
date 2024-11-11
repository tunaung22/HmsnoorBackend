using System;

namespace HmsnoorBackend.Exceptions;

public class HmsCurrencyInsertFailedException : Exception
{
    public HmsCurrencyInsertFailedException()
    {
    }

    public HmsCurrencyInsertFailedException(string? message) : base(message)
    {
    }

    public HmsCurrencyInsertFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
