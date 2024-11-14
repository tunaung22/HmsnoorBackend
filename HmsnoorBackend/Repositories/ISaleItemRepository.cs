using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Repositories;

public interface ISaleItemRepository
{
    IQueryable<TransactionSalesItem> FindAll();
    IQueryable<TransactionSalesItem> FindOneById(string invoiceNo, string itemNo);
    IQueryable<TransactionSalesItem> FindManyById(string invoiceNo, string itemNo);
    IQueryable<TransactionSalesItem> FindManyByInvoiceNo(string invoiceNo);
    Task<int> SaveAsync(TransactionSalesItem entity);
    Task<bool> UpdateByIdAsync(string invoiceNo, string itemNo, TransactionSalesItem entity);
    // Update InvoiceItems by InvoiceNo
    // Task<bool> UpdateByInvoiceNoAsync(string invoiceNo, TransactionSalesItem entity);
    Task<bool> UpdateInvoiceNoAsync(string invoiceNo, string newInvoiceNo);
    Task<bool> DeleteOneById(string invoiceNo, string itemNo);
    Task<bool> DeleteManyByInvoiceNo(string invoiceNo);
    // IQueryable<TransactionSalesItem> FindAllByInvoiceNo(string invoiceNo);
    // IQueryable<TransactionSalesItem>? FindByInvoiceNoAndItemNo(string invoiceNo, string itemNo);


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllByInvoiceNo instead.", false)]
    Task<List<TransactionSalesItem>> GetAllSalesItemByInvoiceNoAsync(string invoiceNo);
    [Obsolete("This method is deprecated. Use GetByInvoiceNoAndItemNo instead.", false)]
    Task<TransactionSalesItem?> GetSaleItemByInvoiceNoAndItemNoAsync(string invoiceNo, string itemNo);
}
