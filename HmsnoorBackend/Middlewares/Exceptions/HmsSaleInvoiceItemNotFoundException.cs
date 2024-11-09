using System;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class HmsSaleInvoiceItemNotFoundException : Exception
{

    public HmsSaleInvoiceItemNotFoundException()
        : base($"Sale items not found.")
    { }

    public HmsSaleInvoiceItemNotFoundException(string invoiceNo)
        : base($"Sale items for invoice number: [{invoiceNo}] not found.")
    { }

    public HmsSaleInvoiceItemNotFoundException(string invoiceNo, Exception innerException)
        : base($"Sale items for invoice number: [{invoiceNo}] not found.", innerException)
    { }

}
