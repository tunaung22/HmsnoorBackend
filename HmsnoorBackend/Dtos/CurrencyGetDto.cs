using System;

namespace HmsnoorBackend.Dtos;

public class CurrencyGetDto
{
    public int CurrencyId { get; set; }
    public String CurrencyName { get; set; } = null!;
}
