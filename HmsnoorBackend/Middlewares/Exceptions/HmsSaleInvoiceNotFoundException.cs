using System;
using System.Runtime.Serialization;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class HmsSaleInvoiceNotFoundException : Exception
{

    public HmsSaleInvoiceNotFoundException() : base($"Sale invoice not found.")
    { }

    public HmsSaleInvoiceNotFoundException(string invoiceNo)
        : base($"Sale invoice number: [{invoiceNo}] not found.")
    { }

    public HmsSaleInvoiceNotFoundException(string invoiceNo, Exception innerException)
        : base($"Sale invoice number: [{invoiceNo}] not found.", innerException)
    { }
}