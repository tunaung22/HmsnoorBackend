using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Interfaces.Repositories;

public interface IItemRepository
{
    IQueryable<ItemHeader> FindAll();
    IQueryable<ItemHeader> FindById(string itemType, string itemNo);
    // IQueryable<ItemHeader> FindByItemNo(string itemNo);
    Task<int> SaveAsync(ItemHeader entity);
    Task<int> UpdateByIdAsync(string itemType, string itemNo, ItemHeader entity);
    Task<int> DeleteByIdAsync(string itemType, string itemNo);


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllAsync instead.", false)]
    Task<List<ItemGetDto>> GetAllItemHeadersAsync();

    [Obsolete("This method is deprecated. Use FindByIdAsync instead.", false)]
    Task<ItemGetDto?> GetItemHeaderByItemNoAsync(string itemNo);

    [Obsolete("This method is deprecated. Use SaveAsync instead.", false)]
    Task<ItemGetDto> SaveItemHeaderAsync(ItemCreateDto data);

}
