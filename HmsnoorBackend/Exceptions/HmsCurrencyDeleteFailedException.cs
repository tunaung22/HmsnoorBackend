using System;

namespace HmsnoorBackend.Exceptions;

class HmsCurrencyDeleteFailedException : Exception
{
    public HmsCurrencyDeleteFailedException()
    {
    }

    public HmsCurrencyDeleteFailedException(string? message) : base(message)
    {
    }

    public HmsCurrencyDeleteFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
