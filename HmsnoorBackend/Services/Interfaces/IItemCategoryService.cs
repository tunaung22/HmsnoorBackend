using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services.Interfaces;

public interface IItemCategoryService
{
    Task<ItemCategoryGetDto> Save_ItemCategory_Async(ItemCategoryCreateDto dto);
    Task<ItemCategoryGetDto> Update_ItemCategory_Async(string itemCategoryId,
        ItemCategoryUpdateDto dto);
    Task<bool> Delete_ItemCategory_Async(string itemCategoryId);

    Task<List<ItemCategoryGetDto>> FindAll_ItemCategory_Async();
    Task<ItemCategoryGetDto?> Find_ById_Async(string itemCategoryId);
}
