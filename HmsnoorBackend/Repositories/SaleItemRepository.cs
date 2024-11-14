using HmsnoorBackend.Data;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly HmsnoorDbContext _context;

    public SaleItemRepository(HmsnoorDbContext context)
    {
        _context = context;
    }


    /*
     * Find MANY Items
     */
    public IQueryable<TransactionSalesItem> FindAll()
    {
        var query = _context.TransactionSalesItems
            .Select(e => new TransactionSalesItem()
            {
                InvoiceNo = e.InvoiceNo,
                ItemNo = e.ItemNo,
                ItemName = e.ItemName!,
                Price = e.Price,
                Quantity = e.Quantity,
                Amount = e.Amount
            });
        return query;
    }

    /*
     * Find ONE Item by Invoice No + Item No
     */
    public IQueryable<TransactionSalesItem> FindOneById(string invoiceNo, string itemNo)
    {
        var query = _context.TransactionSalesItems
            .Where(e => e.InvoiceNo == invoiceNo && e.ItemNo == itemNo)
            .Select(e => new TransactionSalesItem()
            {
                InvoiceNo = e.InvoiceNo,
                ItemNo = e.ItemNo,
                ItemName = e.ItemName!,
                Price = e.Price,
                Quantity = e.Quantity,
                Amount = e.Amount
            });
        return query;
    }



    /*
     * Find MANY Items by Invoice No
     */
    public IQueryable<TransactionSalesItem> FindManyById(string invoiceNo, string itemNo)
    {
        var query = _context.TransactionSalesItems
            .Where(e => e.InvoiceNo == invoiceNo && e.ItemNo == itemNo)
            .Select(e => new TransactionSalesItem()
            {
                InvoiceNo = e.InvoiceNo,
                ItemNo = e.ItemNo,
                ItemName = e.ItemName!,
                Price = e.Price,
                Quantity = e.Quantity,
                Amount = e.Amount
            });
        return query;
    }

    /*
     * Find MANY Items by Invoice No
     */
    public IQueryable<TransactionSalesItem> FindManyByInvoiceNo(string invoiceNo)
    {
        var query = _context.TransactionSalesItems
            .Where(e => e.InvoiceNo == invoiceNo)
            .Select(e => new TransactionSalesItem()
            {
                InvoiceNo = e.InvoiceNo,
                ItemNo = e.ItemNo,
                ItemName = e.ItemName!,
                Price = e.Price,
                Quantity = e.Quantity,
                Amount = e.Amount
            });
        return query;
    }

    /// <summary>
    /// Save TransactionSale
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> SaveAsync(TransactionSalesItem entity)
    {
        _context.TransactionSalesItems.Add(entity);

        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update Invoice No (** INVOICE NO ONLY **)
    /// update invoice no for all the sale items that matched  
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <param name="newInvoiceNo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> UpdateInvoiceNoAsync(string invoiceNo, string newInvoiceNo)
    {
        var itemList = await this.FindManyByInvoiceNo(invoiceNo).ToListAsync();
        if (itemList != null)
        {
            _context.Entry(itemList).State = EntityState.Modified;
            itemList.ForEach(i => i.InvoiceNo = newInvoiceNo);
            return await _context.SaveChangesAsync() > 0;
        }

        throw new HmsSaleInvoiceItemNotFoundException(invoiceNo);
    }

    /// <summary>
    /// Update ONE InvoiceItem by ID (InvoiceNo, ItemNo)
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <param name="itemNo"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> UpdateByIdAsync(string invoiceNo, string itemNo, TransactionSalesItem entity)
    {
        var item = await this.FindOneById(invoiceNo, itemNo).SingleOrDefaultAsync();
        if (item != null)
        {
            _context.Entry(item).State = EntityState.Modified;
            // item.InvoiceNo = entity.InvoiceNo;
            // item.ItemNo = entity.ItemNo;
            item.ItemName = entity.ItemName;
            item.Price = entity.Price;
            item.Quantity = entity.Quantity;
            item.Amount = entity.Amount;

            return await _context.SaveChangesAsync() > 0;
        }

        throw new HmsSaleInvoiceItemNotFoundException(invoiceNo);
    }



    /*
     * Delete ONE Item by Invoice No + Item No
     */
    public async Task<bool> DeleteOneById(string invoiceNo, string itemNo)
    {
        var query = await this.FindOneById(invoiceNo, itemNo).SingleOrDefaultAsync();
        if (query != null)
        {
            _context.TransactionSalesItems.Remove(query);

            return await _context.SaveChangesAsync() > 0;
        }

        throw new HmsSaleInvoiceItemNotFoundException();
    }

    /*
     * Delete MANY Item by Invoice No
     */
    public async Task<bool> DeleteManyByInvoiceNo(string invoiceNo)
    {
        var query = await this.FindManyByInvoiceNo(invoiceNo).ToListAsync();
        if (query.Count > 0)
        {
            _context.TransactionSalesItems.RemoveRange(query);

            return await _context.SaveChangesAsync() > 0;
        }
        throw new HmsSaleInvoiceItemNotFoundException(invoiceNo);
    }

    // public IQueryable<TransactionSalesItem>? FindAllByInvoiceNo(string invoiceNo)
    // {
    //     var query = _context.TransactionSalesItems
    //         .Where(e => e.InvoiceNo == invoiceNo)
    //         .Select(e => new TransactionSalesItem()
    //         {
    //             InvoiceNo = e.InvoiceNo,
    //             ItemNo = e.ItemNo,
    //             ItemName = e.ItemName!,
    //             Price = e.Price,
    //             Quantity = e.Quantity,
    //             Amount = e.Amount
    //         });
    //     return query;
    // }

    // public IQueryable<TransactionSalesItem>? FindByInvoiceNoAndItemNo(string invoiceNo, string itemNo)
    // {
    //     var query = _context.TransactionSalesItems
    //         .Where(e => e.InvoiceNo == invoiceNo && e.ItemNo == itemNo)
    //         .Select(e => new TransactionSalesItem()
    //         {
    //             InvoiceNo = e.InvoiceNo,
    //             ItemNo = e.ItemNo,
    //             ItemName = e.ItemName!,
    //             Price = e.Price,
    //             Quantity = e.Quantity,
    //             Amount = e.Amount
    //         });
    //     return query;
    // }


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllByInvoiceNo instead.", false)]
    public async Task<List<TransactionSalesItem>> GetAllSalesItemByInvoiceNoAsync(string invoiceNo)
    {
        try
        {
            var saleItems = await _context.TransactionSalesItems
                .FromSql($"SELECT * FROM TransactionSalesItem WHERE InvoiceNo={invoiceNo}")
                .ToListAsync();
            // var result = TransactionSalesItemMapper.ToGetDto(saleItems);
            return saleItems;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    [Obsolete("This method is deprecated. Use GetByInvoiceNoAndItemNo instead.", false)]
    public async Task<TransactionSalesItem?> GetSaleItemByInvoiceNoAndItemNoAsync(string invoiceNo, string itemNo)
    {
        // SQL
        // var saleItem = await _context.TransactionSalesItems
        //     .FromSql($"SELECT * FROM TransactionSalesItem WHERE InvoiceNo={invoiceNo} AND ItemNo={itemNo}")
        //     .SingleOrDefaultAsync();
        // var result = TransactionSalesItemMapper.ToGetDto(saleItem);
        // return result;

        // LINQ
        var saleItem = await _context.TransactionSalesItems
            .Where(i => i.InvoiceNo == invoiceNo && i.ItemNo == itemNo)
            .Select(r => new TransactionSalesItem()
            {
                InvoiceNo = r.InvoiceNo,
                ItemNo = r.ItemNo,
                ItemName = r.ItemName!,
                Price = r.Price,
                Quantity = r.Quantity,
                Amount = r.Amount
            })
            .FirstOrDefaultAsync();
        return saleItem;
    }


}
