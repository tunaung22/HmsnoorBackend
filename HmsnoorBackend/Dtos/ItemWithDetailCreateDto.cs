using System;

namespace HmsnoorBackend.Dtos;

/*
    {
        "itemNo": "M001",
        "itemType": "Beverage",
        "itemCategory": "Beverage",
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
    public String ItemNo { get; set; } = null!;
    public String ItemType { get; set; } = null!;
    public String? ItemCategory { get; set; }
    public String ItemName { get; set; } = null!;
    public String? MItemName { get; set; }
    public List<ItemDetailCreateDto> Items { get; set; } = [];

}
