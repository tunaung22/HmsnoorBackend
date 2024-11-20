using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserAccountNotFoundException : Exception
{
    public HmsUserAccountNotFoundException() : base("User Account not found.")
    {
    }

    public HmsUserAccountNotFoundException(string? message) : base(message)
    {
    }

    public HmsUserAccountNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
