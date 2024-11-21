using System;

namespace HmsnoorBackend.Dtos;

public class ItemCategoryCreateDto
{
    public string ItemCategoryId { get; set; } = null!;
    public string? ItemCategoryName { get; set; }
    public string? ItemType { get; set; }
}
