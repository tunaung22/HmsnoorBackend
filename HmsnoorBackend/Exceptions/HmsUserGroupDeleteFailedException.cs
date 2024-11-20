using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserGroupDeleteFailedException : Exception
{

    public HmsUserGroupDeleteFailedException() : base("Delete user group failed.")
    {
    }

    public HmsUserGroupDeleteFailedException(string? message) : base(message)
    {
    }

    public HmsUserGroupDeleteFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
