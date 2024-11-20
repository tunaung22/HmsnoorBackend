using System;

namespace HmsnoorBackend.Exceptions;

public class HmsUserGroupSaveFailedException : Exception
{
    public HmsUserGroupSaveFailedException() : base("User group create failed.")
    {
    }

    public HmsUserGroupSaveFailedException(string? message) : base(message)
    {
    }

    public HmsUserGroupSaveFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
