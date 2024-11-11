using System;

namespace HmsnoorBackend.Dtos;

public class CurrencyUpdateDto
{
    // public int CurrencyId { get; set; }
    public string CurrencyDescription { get; set; } = null!;
    public string? CurrencyNotation { get; set; }
}
