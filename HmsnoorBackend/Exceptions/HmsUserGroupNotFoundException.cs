using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserGroupNotFoundException : Exception
{
    public HmsUserGroupNotFoundException()
    {
    }

    public HmsUserGroupNotFoundException(string? message) : base(message)
    {
    }

    public HmsUserGroupNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
