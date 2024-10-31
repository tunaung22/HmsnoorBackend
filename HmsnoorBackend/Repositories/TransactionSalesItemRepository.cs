using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Repositories;

public class TransactionSalesItemRepository : ITransactionSalesItemRepository
{
    private readonly HmsnoorDbContext _context;

    public TransactionSalesItemRepository(HmsnoorDbContext ctx)
    {
        _context = ctx;
    }

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
