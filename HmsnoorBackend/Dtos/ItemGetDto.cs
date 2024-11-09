using System;

namespace HmsnoorBackend.Dtos;

public class ItemGetDto
{
    public String ItemNo { get; set; } = null!;
    public String ItemType { get; set; } = null!;
    public String? ItemCategory { get; set; }
    public String ItemName { get; set; } = null!;
    public String? MItemName { get; set; }

}
