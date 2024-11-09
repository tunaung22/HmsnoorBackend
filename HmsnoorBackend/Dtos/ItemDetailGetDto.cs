using System;

namespace HmsnoorBackend.Dtos;

public class ItemDetailGetDto
{
    public int Id { get; set; }
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;

    // public CurrencyGetDto Currency { get; set; } = null!;
    public int CurrencyId { get; set; }

    public decimal Price { get; set; }
}
