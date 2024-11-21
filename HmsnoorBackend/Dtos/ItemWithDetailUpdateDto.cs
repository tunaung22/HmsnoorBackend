namespace HmsnoorBackend.Dtos;

public class ItemWithDetailUpdateDto
{
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public ItemCategoryUpdateDto ItemCategory { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public string? MItemName { get; set; }
    public List<ItemDetailUpdateDto> ItemDetails { get; set; } = [];

}
