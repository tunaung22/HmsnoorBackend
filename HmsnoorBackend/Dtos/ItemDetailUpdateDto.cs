using System;

namespace HmsnoorBackend.Dtos;

public class ItemDetailUpdateDto
{
    // public int Id { get; set; }
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public int CurrencyId { get; set; }
    public decimal Price { get; set; }
}
