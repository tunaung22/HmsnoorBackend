namespace HmsnoorBackend.Data.Models;

public partial class ItemDetail
{
    public int Id { get; set; }
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public int CurrencyId { get; set; }
    public decimal Price { get; set; }
}
