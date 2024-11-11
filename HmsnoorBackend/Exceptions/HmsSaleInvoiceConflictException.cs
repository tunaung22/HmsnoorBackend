using System;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class HmsSaleInvoiceConflictException : Exception
{

    public HmsSaleInvoiceConflictException(string invoiceNoFirst, string invoiceNoSecond)
      : base($"Cannot proceed due to the collision of invoice numbers: [{invoiceNoFirst}] :: [{invoiceNoSecond}]")
    { }

    public HmsSaleInvoiceConflictException(string invoiceNoFirst, string invoiceNoSecond, Exception innerException)
        : base($"Cannot proceed due to the collision of invoice numbers: [{invoiceNoFirst}] :: [{invoiceNoSecond}]", innerException)
    { }

}
