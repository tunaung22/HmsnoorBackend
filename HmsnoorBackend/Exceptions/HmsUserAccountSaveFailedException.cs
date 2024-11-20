using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserAccountSaveFailedException : Exception
{
    public HmsUserAccountSaveFailedException() : base("User account create failed.")
    {
    }

    public HmsUserAccountSaveFailedException(string? message) : base(message)
    {
    }

    public HmsUserAccountSaveFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
