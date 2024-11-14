using System;

namespace HmsnoorBackend.Models;

public partial class Currency
{
    public int CurrencyId { get; set; }
    public string CurrencyDescription { get; set; } = null!;

    public string? CurrencyNotation { get; set; }
}
