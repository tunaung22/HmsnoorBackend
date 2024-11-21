namespace HmsnoorBackend.Dtos;

public class ItemWithDetailGetDto
{
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public ItemCategoryGetDto ItemCategory { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public string? MItemName { get; set; }
    public List<ItemDetailGetDto> ItemDetails { get; set; } = [];

}
