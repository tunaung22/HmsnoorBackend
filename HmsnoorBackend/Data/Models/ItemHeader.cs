namespace HmsnoorBackend.Data.Models;

public partial class ItemHeader
{
    public string ItemNo { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public string ItemType { get; set; } = null!;

    public string? ItemCategory { get; set; }

    public string? MItemName { get; set; }
}
