namespace HmsnoorBackend.Middlewares.Exceptions;



public class HmsCurrencyNotFoundException : Exception
{
    // private int currencyId;

    // public HmsCurrencyNotFoundException() : base("Requested currency not found.")
    // {
    // }

    // public HmsCurrencyNotFoundException(int currencyId)
    //     : base($"Currency with id : [{currencyId}] not found.")
    // {
    //     // this.currencyId = currencyId;
    // }

    // public HmsCurrencyNotFoundException(int currencyId, Exception? innerException)
    //     : base($"Currency with id : [{currencyId}] not found.", innerException)
    // {
    // }

    public HmsCurrencyNotFoundException()
    {
    }

    public HmsCurrencyNotFoundException(string? message) : base(message)
    {
    }

    public HmsCurrencyNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}