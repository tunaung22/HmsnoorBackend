namespace HmsnoorBackend.Dtos;

public class ItemWithDetailGetDto
{
    public String ItemNo { get; set; } = null!;
    public String ItemType { get; set; } = null!;
    public String? ItemCategory { get; set; }
    public String ItemName { get; set; } = null!;
    public String? MItemName { get; set; }
    public List<ItemDetailGetDto> ItemDetails { get; set; } = [];

}
