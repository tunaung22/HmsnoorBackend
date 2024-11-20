using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserAccountUpdateFailedException : Exception
{
    public HmsUserAccountUpdateFailedException() : base("User account update failed.")
    {
    }

    public HmsUserAccountUpdateFailedException(string? message) : base(message)
    {
    }

    public HmsUserAccountUpdateFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
