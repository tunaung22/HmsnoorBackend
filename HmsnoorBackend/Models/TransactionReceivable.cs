using System;
using System.Collections.Generic;

namespace HmsnoorBackend.Models;

// TODOs: Generated using Scaffolding from existing database.
// ** needs reviews
public partial class TransactionReceivable
{
    public int Id { get; set; }

    public string? RegistrationNo { get; set; }

    public string? InvoiceNo { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public string? ChargesType { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? Amount { get; set; }
}
