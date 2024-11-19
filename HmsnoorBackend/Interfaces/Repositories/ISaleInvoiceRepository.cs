using HmsnoorBackend.Dtos;
using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Interfaces.Repositories;


public interface ISaleInvoiceRepository
{
    IQueryable<TransactionSale> FindAll();
    // Task<List<TransactionSale>> FindAllAsync();
    IQueryable<TransactionSale?> FindById(string invoiceNo);
    // Task<TransactionSale?> FindByIdAsync(string invoiceNo);
    Task<int> SaveAsync(TransactionSale entity);
    Task<bool> UpdateByIdAsync(string invoiceNo, TransactionSale entity);
    Task<bool> UpdateInvoiceNoAsync(string invoiceNo, string newInvoiceNo);
    Task<bool> DeleteByIdAsync(string invoiceNo);


    /*

    [Invoice]
        SaveInvoice
        UpdateInvoice
        FindAllInvoice
        FindInvoiceById

    [InvoiceItem]
        SaveInvoiceItem
        UpdateInvoiceItem
        DeleteInvoiceItem
        FindInvoiceItemById
        FindInvoiceItemByInvoice
    

    MERGE ====
    [Sales]
        SaveInvoice
        SaveInvoiceItem
        UpdateInvoice
        UpdateInvoiceItem
        DeleteInvoice
        DeleteInvoiceItem
        FindAllInvoice
        FindInvoiceById
        FindInvoiceItemById
        FindInvoiceItemByInvoice
    */

    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use service method instead.", false)]
    Task<InvoiceWithItemsGetDto> CreateTransactionSaleMasterAsync(InvoiceWithItemsCreateDto data);
    [Obsolete("This method is deprecated. Use Fservice method instead.", false)]
    Task<TransactionSale> CreateTransactionSale(TransactionSale data);
    [Obsolete("This method is deprecated. Use service method instead.", false)]
    Task<TransactionSale> GetTransactionSaleByInvoiceNo(string invoiceNo);
    [Obsolete("This method is deprecated. Use service method instead.", false)]
    Task<List<TransactionSale>> GetAllTransactionSalesAsync(string salesType);

}
