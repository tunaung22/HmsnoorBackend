using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.QueryRepositories.Interfaces;

namespace HmsnoorBackend.QueryRepositories;

public class ItemQueryRepository : IItemQueryRepository
{
    private readonly HmsnoorDbContext _context;

    public ItemQueryRepository(HmsnoorDbContext context)
    {
        _context = context;
    }

    public List<ItemWithDetailAndCurrencyGetDto>? FindAllWithDetails()
    {
        /* LEFT JOIN
         * include all ItemHeaders that are not present in ItemDetail 
         */
        // var query = _context.ItemHeaders
        //     .OrderBy(iH => iH.ItemType).ThenBy(iH => iH.ItemNo)
        //     .Select(iH => new ItemWithDetailAndCurrencyGetDto
        //     {
        //         ItemType = iH.ItemType,
        //         ItemNo = iH.ItemNo,
        //         ItemCategory = iH.ItemCategory,
        //         ItemName = iH.ItemName,
        //         MItemName = iH.MItemName,
        //         ItemDetails = _context.ItemDetail
        //             .Where(iD => iD.ItemType == iH.ItemType && iD.ItemNo == iH.ItemNo)
        //             .Select(iD => new ItemDetailWithCurrencyGetDto
        //             {
        //                 Id = iD.Id,
        //                 ItemType = iD.ItemType,
        //                 ItemNo = iD.ItemNo,
        //                 Price = iD.Price,
        //                 Currency = _context.Currency
        //                     .Where(c => c.CurrencyId == iD.CurrencyId)
        //                     .Select(c => new CurrencyGetDto
        //                     {
        //                         CurrencyId = c.CurrencyId,
        //                         CurrencyDescription = c.CurrencyDescription,
        //                         CurrencyNotation = c.CurrencyNotation,
        //                     }).Single()
        //             }).ToList()
        //     }).ToList();


        /* INNER JOIN 
         * exclude ItemHeader not present in ItemDetail
         * More efficient
         */
        var query = _context.ItemHeaders
            .OrderBy(iH => iH.ItemType).ThenBy(iH => iH.ItemNo)
            .Join(_context.ItemDetail,
                iH => new { iH.ItemType, iH.ItemNo },
                iD => new { iD.ItemType, iD.ItemNo },
                (iH, iD) => new ItemWithDetailAndCurrencyGetDto
                {

                    ItemType = iH.ItemType,
                    ItemNo = iH.ItemNo,
                    ItemCategory = iH.ItemCategory,
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
}
