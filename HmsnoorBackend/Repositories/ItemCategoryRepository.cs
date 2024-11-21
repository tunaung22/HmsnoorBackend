using HmsnoorBackend.Data;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Repositories;

public class ItemCategoryRepository : IItemCategoryRepository
{
    private readonly HmsnoorDbContext _context;

    public ItemCategoryRepository(HmsnoorDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync(ItemCategory model)
    {
        _context.Add(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateByIdAsync(string itemCategoryId, ItemCategory model)
    {
        ItemCategory? category = await FindById(itemCategoryId).FirstOrDefaultAsync();
        if (category != null)
        {
            _context.Entry(category).State = EntityState.Modified;

            category.ItemCategoryName = model.ItemCategoryName;
            category.ItemType = model.ItemType;

            return await _context.SaveChangesAsync();
        }
        throw new Exception("Category not found");
    }

    public async Task<int> DeleteByIdAsync(string itemCategoryId)
    {
        ItemCategory? category = await FindById(itemCategoryId).FirstOrDefaultAsync();
        if (category != null)
        {
            _context.ItemCategory.Remove(category);

            return await _context.SaveChangesAsync();
        }

        throw new Exception("Category not found");
    }


    public IQueryable<ItemCategory> FindById(string itemCategoryId)
    {
        var query = _context.ItemCategory
            .Where(c => c.ItemCategoryId == itemCategoryId)
            .Select(c => new ItemCategory
            {
                ItemCategoryId = c.ItemCategoryId,
                ItemCategoryName = c.ItemCategoryName,
                ItemType = c.ItemType,
            });

        return query;
    }

    public IQueryable<ItemCategory> FindAll()
    {
        var query = _context.ItemCategory
            .OrderBy(c => c.ItemCategoryName)
            .Select(c => new ItemCategory
            {
                ItemCategoryId = c.ItemCategoryId,
                ItemCategoryName = c.ItemCategoryName,
                ItemType = c.ItemType,
            });

        return query;
    }

}
