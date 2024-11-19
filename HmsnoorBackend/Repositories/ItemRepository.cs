using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using HmsnoorBackend.Interfaces.Repositories;

namespace HmsnoorBackend.Repositories;

public class ItemRepository : IItemRepository
{

    private readonly HmsnoorDbContext _context;
    private readonly ILogger<ItemRepository> _logger;

    public ItemRepository(HmsnoorDbContext context, ILogger<ItemRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IQueryable<ItemHeader> FindAll()
    {
        var query = _context.ItemHeaders
            .OrderBy(e => e.ItemNo)
            .Select(e => new ItemHeader
            {
                ItemNo = e.ItemNo,
                ItemName = e.ItemName,
                ItemType = e.ItemType,
                ItemCategory = e.ItemCategory,
                MItemName = e.MItemName
            });
        return query;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public IQueryable<ItemHeader> FindById(string itemType, string itemNo)
    {
        try
        {
            var query = _context.ItemHeaders
                .Where(e => e.ItemNo == itemNo && e.ItemType == itemType)
                .Select(e => new ItemHeader
                {
                    ItemNo = e.ItemNo,
                    ItemName = e.ItemName,
                    ItemType = e.ItemType,
                    ItemCategory = e.ItemCategory,
                    MItemName = e.MItemName
                });
            return query;
        }
        catch (System.Exception)
        {
            throw;
        }
    }



    // public IQueryable<ItemHeader> FindByItemNo(string itemNo)
    // {
    //     try
    //     {
    //             var query = _context.ItemHeaders
    //                 .Where(e => e.ItemNo == itemNo)
    //                 .Select(e => new ItemHeader
    //                 {
    //                     ItemNo = e.ItemNo,
    //                     ItemName = e.ItemName,
    //                     ItemType = e.ItemType,
    //                     ItemCategory = e.ItemCategory,
    //                     MItemName = e.MItemName
    //                 });

    //         return query;
    //     }
    //     catch (System.Exception)
    //     {
    //         throw;
    //     }
    // }

    /// <summary>
    /// Save Item
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>int</returns>
    /// <exception cref="Exception"></exception>
    public async Task<int> SaveAsync(ItemHeader entity)
    {
        await _context.ItemHeaders.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update Item by ID (ItemType, ItemNo)
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="HmsItemNotFoundException"></exception>
    public async Task<int> UpdateByIdAsync(string itemType, string itemNo, ItemHeader entity)
    {
        var query = await FindById(itemType, itemNo).SingleOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;

            /** Note: 
            * ItemNo + ItemType => Composite Primary Keys 
            * ItemNo and ItemType Editable ???
            */
            // query.ItemNo = entity.ItemNo;
            // query.ItemType = entity.ItemType;
            query.ItemName = entity.ItemName;
            query.ItemCategory = entity.ItemCategory;
            query.MItemName = entity.MItemName;

            return await _context.SaveChangesAsync();
        }

        throw new HmsItemNotFoundException(itemType, itemNo);
        // throw new Exception("DbUpdateConcurrencyException", ex);
        // catch (DbUpdateConcurrencyException ex)
        // throw new Exception("DbUpdateException", ex);
        // throw new DbUpdateException();
        // catch (DbUpdateException ex)
    }

    /// <summary>
    /// Delete Item by ID
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns>int</returns>
    public async Task<int> DeleteByIdAsync(string itemType, string itemNo)
    {
        var itemHeaders = await FindById(itemType, itemNo).SingleOrDefaultAsync();
        if (itemHeaders != null)
        {
            _context.ItemHeaders.Remove(itemHeaders);
            return await _context.SaveChangesAsync();
        }
        throw new HmsItemNotFoundException(itemType, itemNo);
    }


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllAsync instead.", false)]
    public async Task<List<ItemGetDto>> GetAllItemHeadersAsync()
    {
        // LINQ
        var itemHeaders = await _context.ItemHeaders
            .OrderBy(i => i.ItemNo)
            .Select(i => new ItemGetDto()
            {
                ItemNo = i.ItemNo,
                ItemName = i.ItemName,
                ItemType = i.ItemType,
                ItemCategory = i.ItemCategory,
                MItemName = i.MItemName
            })
            .ToListAsync();
        return itemHeaders;
    }

    [Obsolete("This method is deprecated. Use FindByIdAsync instead.", false)]
    public async Task<ItemGetDto?> GetItemHeaderByItemNoAsync(string itemNo)
    {
        // RAW SQL
        // var itemHeader = await _context.ItemHeaders
        //     .FromSql($"SELECT ItemNo, ItemName, ItemType, ItemCategory, MItemName FROM ItemHeaders WHERE ItemNo={itemNo}")
        //     .SingleAsync();
        // var result = ItemHeaderMapper.ToGetDto(itemHeader);
        // return result;

        // LINQ
        var itemHeader = await _context.ItemHeaders
            .Where(i => i.ItemNo == itemNo)
            .Select(i => new ItemGetDto
            {
                ItemNo = i.ItemNo,
                ItemName = i.ItemName,
                ItemType = i.ItemType,
                ItemCategory = i.ItemCategory,
                MItemName = i.MItemName
            })
            .FirstOrDefaultAsync();

        return itemHeader;
    }

    [Obsolete("This method is deprecated. Use SaveAsync instead.", false)]
    public async Task<ItemGetDto> SaveItemHeaderAsync(ItemCreateDto data)
    {
        // dto to entity
        var entity = ItemMapper.ToEntity(data);

        await _context.ItemHeaders
            .AddAsync(entity);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            // query inserted data
            var createdEntity = await _context.ItemHeaders
                .Where(i => i.ItemNo == data.ItemNo)
                .SingleOrDefaultAsync();
            if (createdEntity != null)
            {
                var createdDto = ItemMapper.ToGetDto(createdEntity);
                return createdDto;
            }
            throw new InvalidOperationException("Cannot fetch inserted item header.");
        }
        throw new Exception("Exception occured while saving Item Header.");
    }
}



