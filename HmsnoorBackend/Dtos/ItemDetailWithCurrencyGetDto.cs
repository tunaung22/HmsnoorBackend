namespace HmsnoorBackend.Dtos;

public class ItemDetailWithCurrencyGetDto
{

    public int Id { get; set; }
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public CurrencyGetDto Currency { get; set; } = null!;
    public decimal Price { get; set; }
}
