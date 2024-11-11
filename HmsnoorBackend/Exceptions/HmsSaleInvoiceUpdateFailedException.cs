using System;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class HmsSaleInvoiceUpdateFailedException : Exception
{
    public HmsSaleInvoiceUpdateFailedException() : base($"Sale invoice update failed.")
    { }

    public HmsSaleInvoiceUpdateFailedException(string invoiceNo)
        : base($"Update failed for Sale Invoice number: [{invoiceNo}].")
    { }

    public HmsSaleInvoiceUpdateFailedException(string invoiceNo, Exception innerException)
        : base($"Update failed for Sale Invoice number: [{invoiceNo}].", innerException)
    { }
}
