namespace HmsnoorBackend.Dtos;

/* sample
    {
        "itemNo": "M001",
        "itemType": "Restaurant",
        "itemCategory": 
        {
            "itemCategoryId": "101",
            "itemCategoryName": "Restaurant",
            "itemType": "Beverage"
        },
        "itemName": "Papaya Juice",
        "mItemName": "PPY-J",
        "items": [
            {
                "currencyId": 1,
                "price": 20000
            }
        ]
    }
 */
public class ItemWithDetailCreateDto
{
    public string ItemNo { get; set; } = null!;
    public string ItemType { get; set; } = null!;
    public string ItemCategory { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public string? MItemName { get; set; }
    public List<ItemDetailCreateDto> ItemDetails { get; set; } = [];
}
