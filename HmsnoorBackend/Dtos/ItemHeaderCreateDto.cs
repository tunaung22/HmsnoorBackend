using System;

namespace HmsnoorBackend.Dtos;

public class ItemHeaderCreateDto
{
    public String ItemNo { get; set; } = null!;
    public String ItemName { get; set; } = null!;
    public String ItemType { get; set; } = null!;
    public String? ItemCategory { get; set; }
    public String? MItemName { get; set; }

}
