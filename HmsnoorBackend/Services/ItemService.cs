using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class ItemService : IItemService
{
    private readonly HmsnoorDbContext _context;
    private readonly ILogger<ItemService> _logger;
    private readonly IItemRepository _itemRepo;
    private readonly IItemDetailRepository _itemDetailRepo;
    private readonly ICurrencyRepository _currencyRepo;

    public ItemService(HmsnoorDbContext context,
                        IItemRepository repository,
                        IItemDetailRepository itemDetailRepo,
                        ICurrencyRepository currencyRepository,
                        ILogger<ItemService> logger)
    {
        _context = context;
        _itemRepo = repository;
        _itemDetailRepo = itemDetailRepo;
        _currencyRepo = currencyRepository;
        _logger = logger;
    }


    // =============== Item + Detail ========================================
    /// <summary>
    /// Find(Item + Detail)
    /// </summary>
    /// <returns>List<ItemWithDetailGetDto></returns>
    public async Task<List<ItemWithDetailGetDto>> FindAllItemsAsync()
    {
        List<ItemWithDetailGetDto> result = [];

        try
        {
            var itemHeaders = await _itemRepo.FindAll().ToListAsync();
            if (itemHeaders != null)
            {
                foreach (var h in itemHeaders)
                {
                    var itemDetails = await _itemDetailRepo
                        .FindAllByItemTypeItemNo(h.ItemType, h.ItemNo)
                        .ToListAsync();
                    result.Add(new ItemWithDetailGetDto
                    {
                        ItemType = h.ItemType,
                        ItemNo = h.ItemNo,
                        ItemCategory = h.ItemCategory,
                        ItemName = h.ItemName,
                        MItemName = h.MItemName,
                        Items = ItemDetailMapper.ToGetDto(itemDetails)
                    });
                }
            }
            return result;
        }
        catch (System.Exception)
        {
            throw;
        }

    }



    /// <summary>
    /// Find (Item + Detail) by Id
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns>ItemWithDetailGetDto?</returns>
    /// <exception cref="NotImplementedException"></exception>    
    public async Task<ItemWithDetailGetDto?> FindItemByIdAsync(string itemType,
                                                                string itemNo)
    {
        ItemWithDetailGetDto result = new();

        var h = await _itemRepo.FindById(itemType, itemNo)
                                .SingleOrDefaultAsync();
        if (h != null)
        {
            var itemDetails = await _itemDetailRepo
                .FindAllByItemTypeItemNo(itemType, itemNo)
                .ToListAsync();

            result.ItemNo = h.ItemNo;
            result.ItemType = h.ItemType;
            result.ItemCategory = h.ItemCategory;
            result.ItemName = h.ItemName;
            result.MItemName = h.MItemName;
            result.Items = ItemDetailMapper.ToGetDto(itemDetails);

        }
        return result;
    }

    /*
     * Save (Item + Detail)
     */
    public async Task<ItemWithDetailGetDto> SaveItemAsync(
                                                ItemWithDetailCreateDto dto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var iHeader = ItemMapper.ToItemHeaderEntity(dto);
            var iDetails = ItemMapper.ToItemDetailEntityList(dto);

            var iHeaderSave = await _itemRepo.SaveAsync(iHeader);

            iDetails.ForEach(async i =>
            {
                var effectedRow = await _itemDetailRepo.SaveAsync(i);
                if (effectedRow == 0)
                    throw new Exception("Insert process for Item failed");
            });


            // ===== QUERY newly created items =====
            ItemWithDetailGetDto finalResult = new();

            var newItemHeader = await _itemRepo
                .FindById(dto.ItemType, dto.ItemNo)
                .SingleOrDefaultAsync();
            if (newItemHeader == null)
                throw new Exception("Fetching for the newly created Item failed");
            var newItemDetailList = await _itemDetailRepo
                .FindAllByItemTypeItemNo(dto.ItemType, dto.ItemNo)
                .ToListAsync();

            finalResult.ItemType = newItemHeader.ItemType;
            finalResult.ItemNo = newItemHeader.ItemNo;
            finalResult.ItemCategory = newItemHeader.ItemCategory;
            finalResult.ItemName = newItemHeader.ItemName;
            finalResult.MItemName = newItemHeader.MItemName;
            // Add each item detail into List<Items> of finalResult
            // foreach (var i in newItemDetailList)
            // {
            //     finalResult.Items.Add(new ItemDetailGetDto
            //     {
            //         Id = i.Id,
            //         ItemType = i.ItemType,
            //         ItemNo = i.ItemNo,
            //         CurrencyId = i.CurrencyId,
            //         Price = i.Price,
            //     });
            // }


            // ===== TRANSACTION COMMIT =====
            await transaction.CommitAsync();
            // ===== RETURN =====
            return finalResult;
        }
        catch (System.Exception)
        {
            // TRANSACTION ROLLBACK
            await transaction.RollbackAsync();
            throw;
        }
    }


    /*
     * Update (Item + Detail)
     */
    public Task<ItemWithDetailGetDto> UpdateItemByIdAsync(
                                                string itemType,
                                                string itemNo,
                                                ItemWithDetailUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    // public async Task<ItemGetDto> DeleteWithDetailByIdAsync(string itemType, string itemNo)
    // {
    //     using var transaction = await _context.Database.BeginTransactionAsync();

    //     try
    //     {
    //      // Check Item is used in sales
    //      // Delete: Item, ItemDetail
    //     }
    //     catch (System.Exception)
    //     {
    //         await transaction.RollbackAsync();
    //         throw;
    //     }
    // }


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllAsync instead.", false)]
    public async Task<List<ItemGetDto>> GetAllItemHeadersAsync()
    {
        var result = await _itemRepo.GetAllItemHeadersAsync();

        return result;
    }
    [Obsolete("This method is deprecated. Use SaveAsync instead.", false)]
    public async Task<ItemGetDto> SaveItemHeaderAsync(ItemCreateDto requestBody)
    {
        return await _itemRepo.SaveItemHeaderAsync(requestBody);

    }

}
