using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.QueryRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.QueryRepositories;

public class ItemQueryRepository : IItemQueryRepository
{
    private readonly HmsnoorDbContext _context;

    public ItemQueryRepository(HmsnoorDbContext context)
    {
        _context = context;
    }

    public List<ItemWithDetailGetDto>? FindAllWithDetails()
    {
        /* LEFT JOIN
         * include all ItemHeaders that are not present in ItemDetail 
         */
        var query1 = _context.ItemHeaders
            .OrderBy(iH => iH.ItemType)
            .ThenBy(iH => iH.ItemNo)
            .Select(iH => new ItemWithDetailGetDto
            {
                ItemType = iH.ItemType,
                ItemNo = iH.ItemNo,
                ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                ItemName = iH.ItemName,
                MItemName = iH.MItemName,
                ItemDetails = _context.ItemDetail
                    .Where(iD => iD.ItemType == iH.ItemType && iD.ItemNo == iH.ItemNo)
                    .Select(iD => new ItemDetailWithCurrencyGetDto
                    {
                        Id = iD.Id,
                        ItemType = iD.ItemType,
                        ItemNo = iD.ItemNo,
                        Price = iD.Price,
                        Currency = _context.Currency
                            .Where(c => c.CurrencyId == iD.CurrencyId)
                            .Select(c => new CurrencyGetDto
                            {
                                CurrencyId = c.CurrencyId,
                                CurrencyDescription = c.CurrencyDescription,
                                CurrencyNotation = c.CurrencyNotation,
                            }).SingleOrDefault()!
                    }).ToList()
            }).ToList();


        /* INNER JOIN 
         * exclude ItemHeader not present in ItemDetail
         * More efficient
         * BUT ** item detail only got one item
         */
        var query = _context.ItemHeaders
            .OrderBy(iH => iH.ItemType).ThenBy(iH => iH.ItemNo)
            .Join(_context.ItemDetail,
                iH => new { iH.ItemType, iH.ItemNo },
                iD => new { iD.ItemType, iD.ItemNo },
                (iH, iD) => new ItemWithDetailGetDto
                {

                    ItemType = iH.ItemType,
                    ItemNo = iH.ItemNo,
                    ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                    ItemName = iH.ItemName,
                    MItemName = iH.MItemName,
                    ItemDetails = new List<ItemDetailWithCurrencyGetDto>
                        {
                            new ()
                            {
                                Id = iD.Id,
                                ItemType = iD.ItemType,
                                ItemNo = iD.ItemNo,
                                Price = iD.Price,
                                Currency = _context.Currency
                                    .Where(c=> c.CurrencyId == iD.CurrencyId)
                                    .Select(c=> new CurrencyGetDto
                                    {
                                        CurrencyId = c.CurrencyId,
                                        CurrencyDescription = c.CurrencyDescription,
                                        CurrencyNotation = c.CurrencyNotation,
                                    }).FirstOrDefault()!
                            }
                        }
                }).ToList();

        return query;
    }

    public IQueryable<ItemWithDetailGetDto> FindAllWithDetailsQuery()
    {
        var leftJoinQuery = _context.ItemHeaders
            .OrderBy(iH => iH.ItemType)
            .ThenBy(iH => iH.ItemNo)
            .Select(iH => new ItemWithDetailGetDto
            {
                ItemType = iH.ItemType,
                ItemNo = iH.ItemNo,
                ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                ItemName = iH.ItemName,
                MItemName = iH.MItemName,
                ItemDetails = _context.ItemDetail
                    .Where(iD => iD.ItemType == iH.ItemType
                        && iD.ItemNo == iH.ItemNo)
                    .Select(iD => new ItemDetailWithCurrencyGetDto
                    {
                        Id = iD.Id,
                        ItemType = iD.ItemType,
                        ItemNo = iD.ItemNo,
                        Price = iD.Price,
                        Currency = _context.Currency
                            .Where(c => c.CurrencyId == iD.CurrencyId)
                            .Select(c => new CurrencyGetDto
                            {
                                CurrencyId = c.CurrencyId,
                                CurrencyDescription = c.CurrencyDescription,
                                CurrencyNotation = c.CurrencyNotation,
                            }).SingleOrDefault()!
                    }).ToList()
            });

        var innerJoinQuery = _context.ItemHeaders
            .OrderBy(iH => iH.ItemType)
            .ThenBy(iH => iH.ItemNo)
            .Join(_context.ItemDetail,
                iH => new { iH.ItemType, iH.ItemNo },
                iD => new { iD.ItemType, iD.ItemNo },
                (iH, iD) => new ItemWithDetailGetDto
                {

                    ItemType = iH.ItemType,
                    ItemNo = iH.ItemNo,
                    ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                    ItemName = iH.ItemName,
                    MItemName = iH.MItemName,
                    ItemDetails = _context.ItemDetail
                        .Where(iD => iD.ItemType == iH.ItemType
                            && iD.ItemNo == iH.ItemNo)
                        .Select(iD => new ItemDetailWithCurrencyGetDto
                        {
                            Id = iD.Id,
                            ItemType = iD.ItemType,
                            ItemNo = iD.ItemNo,
                            Price = iD.Price,
                            Currency = _context.Currency
                                    .Where(c => c.CurrencyId == iD.CurrencyId)
                                    .Select(c => new CurrencyGetDto
                                    {
                                        CurrencyId = c.CurrencyId,
                                        CurrencyDescription = c.CurrencyDescription,
                                        CurrencyNotation = c.CurrencyNotation,
                                    }).FirstOrDefault()!
                        }).ToList()
                });

        return innerJoinQuery;
    }

    public ItemWithDetailGetDto? FindWithDetailsById(string itemType, string itemNo)
    {
        var query = _context.ItemHeaders
            .Where(iH => iH.ItemType == itemType && iH.ItemNo == itemNo)
            .Join(_context.ItemDetail,
                iH => new { iH.ItemType, iH.ItemNo },
                iD => new { iD.ItemType, iD.ItemNo },
                (iH, iD) => new ItemWithDetailGetDto
                {
                    ItemType = iH.ItemType,
                    ItemNo = iH.ItemNo,
                    ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                    ItemName = iH.ItemName,
                    MItemName = iH.MItemName,
                    ItemDetails = new List<ItemDetailWithCurrencyGetDto>
                    {
                        new ()
                        {
                            Id = iD.Id,
                            ItemType = iD.ItemType,
                            ItemNo = iD.ItemNo,
                            Price = iD.Price,
                            Currency = _context.Currency
                                .Where(c=> c.CurrencyId == iD.CurrencyId)
                                .Select(c=> new CurrencyGetDto
                                {
                                    CurrencyId = c.CurrencyId,
                                    CurrencyDescription = c.CurrencyDescription,
                                    CurrencyNotation = c.CurrencyNotation,
                                }).FirstOrDefault()!
                        }
                    }
                }).SingleOrDefault();

        return query;
    }

    public IQueryable<ItemWithDetailGetDto?> FindWithDetailsByIdQuery(string itemType, string itemNo)
    {
        // left join query
        var query = _context.ItemHeaders
            .Where(iH => iH.ItemType == itemType
                && iH.ItemNo == itemNo)
            .Select(iH => new ItemWithDetailGetDto
            {
                ItemType = iH.ItemType,
                ItemNo = iH.ItemNo,
                ItemCategory = _context.ItemCategory
                    .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
                    .Select(cat => new ItemCategoryGetDto
                    {
                        ItemCategoryId = cat.ItemCategoryId,
                        ItemCategoryName = cat.ItemCategoryName,
                        ItemType = cat.ItemType,
                    }).SingleOrDefault()!,
                ItemName = iH.ItemName,
                MItemName = iH.MItemName,
                ItemDetails = _context.ItemDetail
                    .OrderBy(iD => iD.CurrencyId)
                    .ThenBy(iD => iD.Price)
                    .Where(iD => iD.ItemType == iH.ItemType
                        && iD.ItemNo == iH.ItemNo)
                    .Select(iD => new ItemDetailWithCurrencyGetDto
                    {
                        Id = iD.Id,
                        ItemType = iD.ItemType,
                        ItemNo = iD.ItemNo,
                        Price = iD.Price,
                        Currency = _context.Currency
                            .Where(c => c.CurrencyId == iD.CurrencyId)
                            .Select(c => new CurrencyGetDto
                            {
                                CurrencyId = c.CurrencyId,
                                CurrencyDescription = c.CurrencyDescription,
                                CurrencyNotation = c.CurrencyNotation,
                            }).SingleOrDefault()!
                    }).ToList()
            });


        // var innerJoinQuery = _context.ItemHeaders
        //     .Where(iH => iH.ItemType == itemType && iH.ItemNo == itemNo)
        //     .Join(_context.ItemDetail,
        //         iH => new { iH.ItemType, iH.ItemNo },
        //         iD => new { iD.ItemType, iD.ItemNo },
        //         (iH, iD) => new ItemWithDetailAndCurrencyGetDto
        //         {
        //             ItemType = iH.ItemType,
        //             ItemNo = iH.ItemNo,
        //             ItemCategory = _context.ItemCategory
        //                 .Where(cat => cat.ItemCategoryName == iH.ItemCategory)
        //                 .Select(cat => new ItemCategoryGetDto
        //                 {
        //                     ItemCategoryId = cat.ItemCategoryId,
        //                     ItemCategoryName = cat.ItemCategoryName,
        //                     ItemType = cat.ItemType,
        //                 }).SingleOrDefault()!,
        //             ItemName = iH.ItemName,
        //             MItemName = iH.MItemName,
        //             ItemDetails = _context.ItemDetail
        //                 .OrderBy(iD => iD.CurrencyId)
        //                 .ThenBy(iD => iD.Price)
        //                 .Where(iD => iD.ItemType == iH.ItemType
        //                     && iD.ItemNo == iH.ItemNo)
        //                 .Select(iD => new ItemDetailWithCurrencyGetDto
        //                 {
        //                     Id = iD.Id,
        //                     ItemType = iD.ItemType,
        //                     ItemNo = iD.ItemNo,
        //                     Price = iD.Price,
        //                     Currency = _context.Currency
        //                         .Where(c => c.CurrencyId == iD.CurrencyId)
        //                         .Select(c => new CurrencyGetDto
        //                         {
        //                             CurrencyId = c.CurrencyId,
        //                             CurrencyDescription = c.CurrencyDescription,
        //                             CurrencyNotation = c.CurrencyNotation,
        //                         }).SingleOrDefault()!
        //                 }).ToList()
        //         });


        return query;
    }
}
