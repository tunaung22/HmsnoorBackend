using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class ItemCategoryMapper
{
    public static ItemCategory ToEntity(ItemCategoryCreateDto createDto)
    {

        return new ItemCategory
        {
            ItemCategoryId = createDto.ItemCategoryId,
            ItemCategoryName = createDto.ItemCategoryName,
            ItemType = createDto.ItemType,
        };

    }
    public static ItemCategory ToEntity(ItemCategoryUpdateDto updateDto)
    {

        return new ItemCategory
        {
            // ItemCategoryId = updateDto.ItemCategoryId,
            ItemCategoryName = updateDto.ItemCategoryName,
            ItemType = updateDto.ItemType,
        };

    }

    public static ItemCategoryGetDto ToGetDto(ItemCategory entity)
    {
        return new ItemCategoryGetDto
        {
            ItemCategoryId = entity.ItemCategoryId,
            ItemCategoryName = entity.ItemCategoryName,
            ItemType = entity.ItemType,
        };
    }

    public static List<ItemCategoryGetDto> ToGetDto(List<ItemCategory> entity)
    {
        return entity.Select(ToGetDto).ToList();
    }
}
