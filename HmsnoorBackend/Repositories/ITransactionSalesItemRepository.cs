using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Repositories;

public interface ITransactionSalesItemRepository
{
    Task<List<TransactionSalesItem>> GetAllSalesItemByInvoiceNoAsync(string invoiceNo);

    Task<TransactionSalesItem?> GetSaleItemByInvoiceNoAndItemNoAsync(string invoiceNo, string itemNo);

}
