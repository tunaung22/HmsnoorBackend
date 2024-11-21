namespace HmsnoorBackend.Dtos;

public class ItemWithDetailGetDto
{
    public String ItemNo { get; set; } = null!;
    public String ItemType { get; set; } = null!;
    public ItemCategoryGetDto ItemCategory { get; set; } = null!;
    public String ItemName { get; set; } = null!;
    public String? MItemName { get; set; }
    public List<ItemDetailWithCurrencyGetDto> ItemDetails { get; set; } = [];
}
