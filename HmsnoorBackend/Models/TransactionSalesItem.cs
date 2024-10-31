using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HmsnoorBackend.Models;

public partial class TransactionSalesItem
{
    [Required]
    public string InvoiceNo { get; set; } = null!;

    [Required]
    public string ItemNo { get; set; } = null!;

    [Required]
    public string? ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }
}
