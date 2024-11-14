using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services;

public interface IItemService
{
    // =============== Item + Detail ========================================
    // Find (Item + Detail)
    Task<List<ItemWithDetailGetDto>> FindAllItemsAsync();

    // Find (Item + Detail) + Currency
    Task<List<ItemWithDetailAndCurrencyGetDto>> FindAllItemsWithCurrencyAsync();

    // Find (Item + Detail) by Type

    // Find (Item + Detail) by Id
    Task<ItemWithDetailGetDto?> FindItemByIdAsync(string itemType,
                                                    string itemNo);

    // Save (Item), ITEM ONLY
    // ???

    // Save (Item + Detail)
    Task<ItemWithDetailGetDto> SaveItemAsync(ItemWithDetailCreateDto dto);

    // Update (Item + Detail)
    Task<ItemWithDetailGetDto> UpdateItemByIdAsync(
        string itemType,
        string itemNo,
        ItemWithDetailUpdateDto dto);

    // Update ID (Item + Detail)
    // Task<ItemWithDetailGetDto> UpdateItemIdAsync(string itemType, string itemNo, ItemWithDetailUpdateDto dto);

    // Delete Item, ** need to check Item are used in sale or anywhere else
    // ???
    // Task<ItemGetDto> DeleteItemAsync(string itemType, string itemNo);



    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllAsync instead.", false)]
    Task<List<ItemGetDto>> GetAllItemHeadersAsync();
    [Obsolete("This method is deprecated. Use SaveAsync instead.", false)]
    Task<ItemGetDto> SaveItemHeaderAsync(ItemCreateDto requestBody);
}
