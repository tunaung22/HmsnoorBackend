using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace HmsnoorBackend.Repositories;

public class ItemDetailRepository : IItemDetailRepository
{
    private readonly HmsnoorDbContext _context;

    public ItemDetailRepository(HmsnoorDbContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Find All Item Detail
    /// </summary>
    /// <returns>IQueryable<ItemDetail></returns>
    public IQueryable<ItemDetail> FindAll()
    {
        var query = _context.ItemDetail
            .Select(e => new ItemDetail
            {
                Id = e.Id,
                ItemNo = e.ItemNo,
                ItemType = e.ItemType,
                CurrencyId = e.CurrencyId,
                Price = e.Price,
            });
        return query;
    }

    /// <summary>
    /// Find Item Detail by Id (ItemType, ItemNo)
    /// </summary>
    /// <param name="id"></param>
    /// <returns>IQueryable<ItemDetail></returns>
    public IQueryable<ItemDetail> FindById(int id)
    {
        var query = _context.ItemDetail
            .Where(e => e.Id == id)
            .Select(e => new ItemDetail
            {
                Id = e.Id,
                ItemNo = e.ItemNo,
                ItemType = e.ItemType,
                CurrencyId = e.CurrencyId,
                Price = e.Price,
            });
        return query;
    }

    /// <summary>
    /// Find Item Detail by Id (ItemType, ItemNo)
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns>IQueryable<ItemDetail></returns>
    public IQueryable<ItemDetail> FindAllByItemTypeItemNo(string itemType, string itemNo)
    {
        var query = _context.ItemDetail
            .Where(e => e.ItemNo == itemNo && e.ItemType == itemType)
            .Select(e => new ItemDetail
            {
                Id = e.Id,
                ItemNo = e.ItemNo,
                ItemType = e.ItemType,
                CurrencyId = e.CurrencyId,
                Price = e.Price,
            });
        return query;
    }

    // ** MOCK
    // public IQueryable<ItemDetail> FindAllWithCurrencyByItemTypeItemNo(string itemType, string itemNo)
    // {
    //     // 1. ItemDetail = Find ItemDetail by (ItemType, ItemNo)
    //     // 2. Loop ItemDetail:
    //     //          Currency = Find Currency by ID
    //     var itemDetails = _context.ItemDetail
    //         .Where(e => e.ItemNo == itemNo && e.ItemType == itemType)
    //         .Select(e => new ItemDetail
    //         {
    //             Id = e.Id,
    //             ItemNo = e.ItemNo,
    //             ItemType = e.ItemType,
    //             CurrencyId = e.CurrencyId,
    //             Price = e.Price,
    //         });
    //     itemDetails.ForEachAsync(i =>
    //     {
    //         var q = _context.Currency
    //             .Where(e => e.CurrencyId == i.CurrencyId)
    //             .Select(e => new Currency
    //             {
    //                 CurrencyId = e.CurrencyId,
    //                 CurrencyName = e.CurrencyName
    //             });
    //     });
    //     return query;
    // }



    /// <summary>
    /// Save Item Detail
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>int</returns>
    public async Task<int> SaveAsync(ItemDetail entity)
    {
        await _context.ItemDetail.AddAsync(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateByIdAsync(int id, ItemDetail entity)
    {
        var query = await FindById(id).SingleOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;
            query.CurrencyId = entity.CurrencyId;
            query.Price = entity.Price;

            return await _context.SaveChangesAsync();
        }
        // TODO: throw specific exception: HmsItemDetailNotFoundException
        throw new Exception();
    }


    /// <summary>
    /// Update Item Detail by (ItemType, ItemNo)
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    // public async Task<int> UpdateByIdAsync(string itemType, string itemNo, ItemDetail entity)
    // {
    //     var query = await FindById(itemType, itemNo).SingleOrDefaultAsync();
    //     if (query != null)
    //     {
    //         _context.Entry(query).State = EntityState.Modified;
    //         query.CurrencyId = entity.CurrencyId;
    //         query.Price = entity.Price;

    //         return await _context.SaveChangesAsync();
    //     }
    //     // TODO: throw specific exception: HmsItemDetailNotFoundException
    //     throw new Exception();
    // }

    /// <summary>
    /// Delete by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<int> DeleteByIdAsync(int id)
    {
        var query = await FindById(id).SingleOrDefaultAsync();
        if (query != null)
        {
            _context.Remove(query);
            return await _context.SaveChangesAsync();
        }
        // TODO: throw specific exception: HmsItemDetailNotFoundException
        throw new Exception();
    }

    /// <summary>
    /// Delete by (ItemType, ItemNo)
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    // public async Task<int> DeleteByIdAsync(string itemType, string itemNo)
    // {
    //     var query = await FindById(itemType, itemNo).SingleOrDefaultAsync();
    //     if (query != null)
    //     {
    //         _context.Remove(query);
    //         return await _context.SaveChangesAsync();
    //     }
    //     // TODO: throw specific exception: HmsItemDetailNotFoundException
    //     throw new Exception();
    // }

    // Task<int> DeleteByPriceById(int id, decimal price);
    // Task<int> DeleteByPriceById(string itemType, string itemNo, decimal price);
    // Task<int> DeleteByPriceById(int id, decimal price, string condition);
    // Task<int> DeleteByPriceById(string itemType, string itemNo, decimal price, string condition);
}
