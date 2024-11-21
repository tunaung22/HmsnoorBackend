using System.Runtime.CompilerServices;
using HmsnoorBackend.Data;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.QueryRepositories.Interfaces;
using HmsnoorBackend.Repositories.Interfaces;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class ItemService : IItemService
{
    private readonly ILogger<ItemService> _logger;
    private readonly HmsnoorDbContext _context;
    private readonly IItemQueryRepository _itemQueryRepo;
    private readonly IItemRepository _itemRepo;
    private readonly IItemDetailRepository _itemDetailRepo;
    private readonly ICurrencyRepository _currencyRepo;

    public ItemService(
        ILogger<ItemService> logger,
        HmsnoorDbContext context,
        IItemQueryRepository itemQueryRepo,
        IItemRepository itemRepo,
        IItemDetailRepository itemDetailRepo,
        ICurrencyRepository currencyRepository)
    {
        _logger = logger;
        _context = context;
        _itemQueryRepo = itemQueryRepo;
        _itemRepo = itemRepo;
        _itemDetailRepo = itemDetailRepo;
        _currencyRepo = currencyRepository;
    }


    /*
    * Save (Item + Detail)
    */
    public async Task<ItemWithDetailAndCurrencyGetDto> SaveItemAsync(
                                                ItemWithDetailCreateDto createDto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Extract createDto into different enities
            var iHeader = ItemMapper.ToItemHeaderEntity(createDto);
            var iDetails = ItemMapper.ToItemDetailEntityList(createDto);

            var iHeaderSave = await _itemRepo.SaveAsync(iHeader);

            iDetails.ForEach(async i =>
            {
                var effectedRow = await _itemDetailRepo.SaveAsync(i);
                if (effectedRow == 0)
                    throw new Exception("Insert process for Item failed");
            });


            // ===== QUERY newly created items =====
            // ItemWithDetailGetDto finalResult = new();

            // var newItemHeader = await _itemRepo
            //     .FindById(createDto.ItemType, createDto.ItemNo)
            //     .SingleOrDefaultAsync();
            // if (newItemHeader == null)
            //     throw new Exception("Fetching for the newly created Item failed");
            // var newItemDetailList = await _itemDetailRepo
            //     .FindAllByItemTypeItemNo(createDto.ItemType, createDto.ItemNo)
            //     .ToListAsync();

            // finalResult.ItemType = newItemHeader.ItemType;
            // finalResult.ItemNo = newItemHeader.ItemNo;
            // finalResult.ItemCategory = newItemHeader.ItemCategory;
            // finalResult.ItemName = newItemHeader.ItemName;
            // finalResult.MItemName = newItemHeader.MItemName;


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

            var finalResult = await FindItemByIdAsync(
                createDto.ItemType,
                createDto.ItemNo);

            if (finalResult == null)
                throw new Exception("Exception at retrieving created item.");

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


    /// <summary>
    /// Find (Item + Detail + Category + Currency) by Id
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNo"></param>
    /// <returns>ItemWithDetailAndCurrencyGetDto?</returns>
    public async Task<ItemWithDetailAndCurrencyGetDto?> FindItemByIdAsync(string itemType,
                                                                string itemNo)
    {
        // var item = _itemQueryRepo.FindWithDetailsById(itemType, itemNo);
        // return Task.FromResult(item);

        var item = await _itemQueryRepo
            .FindWithDetailsByIdQuery(itemType, itemNo)
            .SingleOrDefaultAsync();

        return item;
    }

    /// <summary>
    /// Find(Item + Detail)
    /// </summary>
    /// <returns>List<ItemWithDetailGetDto></returns>
    // public async Task<List<ItemWithDetailGetDto>> FindAllItemsAsync()
    // {
    //     List<ItemWithDetailGetDto> result = [];

    //     try
    //     {
    //         var itemHeaders = await _itemRepo.FindAll().ToListAsync();
    //         if (itemHeaders != null)
    //         {
    //             foreach (var h in itemHeaders)
    //             {
    //                 var itemDetails = await _itemDetailRepo
    //                     .FindAllByItemTypeItemNo(h.ItemType, h.ItemNo)
    //                     .ToListAsync();
    //                 result.Add(new ItemWithDetailGetDto
    //                 {
    //                     ItemType = h.ItemType,
    //                     ItemNo = h.ItemNo,
    //                     ItemCategory = h.ItemCategory,
    //                     ItemName = h.ItemName,
    //                     MItemName = h.MItemName,
    //                     ItemDetails = ItemDetailMapper.ToGetDto(itemDetails)
    //                 });
    //             }
    //         }
    //         return result;
    //     }
    //     catch (System.Exception)
    //     {
    //         throw;
    //     }
    // }

    public async Task<List<ItemWithDetailAndCurrencyGetDto>?> FindAllItemsWithDetails()
    {
        // var items = _itemQueryRepo.FindAllWithDetails();
        var items = await _itemQueryRepo.FindAllWithDetailsQuery().ToListAsync();
        return items;
    }



    /// <summary>
    /// Find(Item + Detail) + Currency
    /// </summary>
    /// <returns>List<ItemWithDetailAndCurrencyGetDto></returns>
    // public async Task<List<ItemWithDetailAndCurrencyGetDto>> FindAllItemsWithCurrencyAsync()
    // {
    //     List<ItemWithDetailAndCurrencyGetDto> result = [];
    //     List<ItemDetailWithCurrencyGetDto> itemDetailWithCurrency = [];

    //     try
    //     {
    //         var itemHeaders = await _itemRepo.FindAll().ToListAsync();

    //         if (itemHeaders != null)
    //         {
    //             foreach (var iHeader in itemHeaders)
    //             {

    //                 List<ItemDetail>? itemDetails = await _itemDetailRepo
    //                     .FindAllByItemTypeItemNo(iHeader.ItemType, iHeader.ItemNo)
    //                     .ToListAsync();

    //                 // itemDetails.ForEach(async item =>
    //                 foreach (var item in itemDetails)
    //                 {
    //                     var currency = await _currencyRepo
    //                         .FindById(item.CurrencyId)
    //                         .FirstOrDefaultAsync();

    //                     CurrencyGetDto? currencyDto = new();

    //                     if (currency != null)
    //                         currencyDto = CurrencyMapper.ToGetDto(currency);

    //                     itemDetailWithCurrency.Add(new()
    //                     {
    //                         ItemType = item.ItemType,
    //                         ItemNo = item.ItemNo,
    //                         Currency = currencyDto,
    //                         Price = item.Price
    //                     });
    //                 };

    //                 result.Add(new ItemWithDetailAndCurrencyGetDto
    //                 {
    //                     ItemType = iHeader.ItemType,
    //                     ItemNo = iHeader.ItemNo,
    //                     ItemCategory = iHeader.ItemCategory,
    //                     ItemName = iHeader.ItemName,
    //                     MItemName = iHeader.MItemName,
    //                     ItemDetails = itemDetailWithCurrency
    //                 });
    //             };

    //         }

    //         return result;
    //     }
    //     catch (System.Exception)
    //     {
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
