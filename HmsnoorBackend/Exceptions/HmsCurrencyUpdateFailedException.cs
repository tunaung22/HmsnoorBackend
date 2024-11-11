using System;

namespace HmsnoorBackend.Exceptions;

public class HmsCurrencyUpdateFailedException : Exception

{
    public HmsCurrencyUpdateFailedException()
    {
    }

    public HmsCurrencyUpdateFailedException(string? message) : base(message)
    {
    }

    public HmsCurrencyUpdateFailedException(string? message, Exception? innerException) : base(message, innerException)
    {

    }
}
