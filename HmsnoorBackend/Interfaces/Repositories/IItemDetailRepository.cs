using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Interfaces.Repositories;

public interface IItemDetailRepository
{
    IQueryable<ItemDetail> FindAll();

    // ** actual id is (id int field)
    IQueryable<ItemDetail> FindById(int id);

    // Find (item detail) by itemType, itemNo
    IQueryable<ItemDetail> FindAllByItemTypeItemNo(string itemType, string itemNo);

    // IQueryable<ItemHeader> FindByItemNo(string itemNo);

    Task<int> SaveAsync(ItemDetail entity);

    Task<int> UpdateByIdAsync(int id, ItemDetail entity);

    // Task<int> UpdateByIdAsync(string itemType, string itemNo, ItemHeader entity);

    Task<int> DeleteByIdAsync(int id);
    // Task<int> DeleteByIdAsync(string itemType, string itemNo);

    // Task<int> DeleteByPriceById(int id, decimal price);
    // Task<int> DeleteByPriceById(string itemType, string itemNo, decimal price);
    // Task<int> DeleteByPriceById(int id, decimal price, string condition);
    // Task<int> DeleteByPriceById(string itemType, string itemNo, decimal price, string condition);

}
