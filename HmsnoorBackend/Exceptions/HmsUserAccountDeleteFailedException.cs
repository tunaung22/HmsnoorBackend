using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserAccountDeleteFailedException : Exception
{
    public HmsUserAccountDeleteFailedException() : base("Delete User Account failed.")
    {
    }

    public HmsUserAccountDeleteFailedException(string? message) : base(message)
    {
    }

    public HmsUserAccountDeleteFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
