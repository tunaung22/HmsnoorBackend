using System;

namespace HmsnoorBackend.Exceptions;

public class HmsCurrencyConflictException : Exception
{

    public HmsCurrencyConflictException()
    {
    }

    public HmsCurrencyConflictException(string? message) : base(message)
    {
    }

    public HmsCurrencyConflictException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

}
