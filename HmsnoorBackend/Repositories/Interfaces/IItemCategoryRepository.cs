using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Repositories.Interfaces;

public interface IItemCategoryRepository
{
    Task<int> SaveAsync(ItemCategory model);
    Task<int> UpdateByIdAsync(string itemCategoryId, ItemCategory model);
    Task<int> DeleteByIdAsync(string itemCategoryId);

    IQueryable<ItemCategory> FindById(string itemCategoryId);
    // IQueryable<ItemCategory> FindByItemNo(string itemNo);
    IQueryable<ItemCategory> FindAll();
}
