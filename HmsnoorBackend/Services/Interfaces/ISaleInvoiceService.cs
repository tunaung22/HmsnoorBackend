using HmsnoorBackend.Data.Models.Filters;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.SaleInvoices;

namespace HmsnoorBackend.Services.Interfaces;

public interface ISaleInvoiceService
{
    // =============== Invoice + Invoice Item ==================================================
    // Update (Invoice) and Update (Invoice Items)
    // ** Do we need to update only invoice items?
    // ** NO -> If [invoice items] changed, [invoice] also needs to update. Eg: Total amount
    // ** Do we need to update only invoice?
    // ** NO -> Changes in [invoice] won't impact on [invoice items].
    //          But invoice item is bind to invoice, so better glue invoice with invoice items

    // Do we need ???
    // Find ALL(Invoice), just for fetching Invoices without its Items
    // Task<List<SaleInvoiceGetDto>> FindAllInvoiceAsync();
    // Find (Invoice) by Type, just for fetching Invoices without its Items for light weight.
    // Task<List<SaleInvoiceGetDto>> FindAllInvoiceByTypeAsync(string salesType);

    // Find (Invoice + Invoice Items)
    [Obsolete("This method is deprecated. Use FindAll_Invoice_2_Async instead.", false)]
    Task<List<InvoiceWithItemsGetDto>> FindAll_Invoice_Async(string? saleType);

    Task<SaleInvoiceGetDTO> FindAll_InvoiceWithDetail_Paginated_Async(
        string? saleType,
        PaginationFilter filter,
        string currentUrl);
    Task<List<InvoiceWithItemsGetDto>> FindAll_InvoiceWithDetail_Async(string? saleType, PaginationFilter filter);
    // Find (Invoice + Invoice Item) by Type
    // Task<List<InvoiceWithItemsGetDto>> FindAllInvoiceByTypeAsync(string salesType);

    // Find (Invoice + Invoice Item) by ID (Invoice No)
    Task<InvoiceWithItemsGetDto?> Find_ById_Async(string invoiceNo);

    // Find (Invoice) by ID (Invoice No)
    // Task<TransactionSale?> FindInvoiceByIdAsync(string invoiceNo)

    // Save (Invoice), INVOICE ONLY. ** do we actually need this??
    Task<InvoiceGetDto> SaveSingleInvoice_Async(InvoiceCreateDto dto);

    // Save (Invoice + Invoice Items)
    Task<InvoiceWithItemsGetDto> SaveInvoice_Async(InvoiceWithItemsCreateDto dto);

    // Update Invoice No (Invoice No + Invoice Items), ** need to update to both Invoice + Invoice Items
    Task<InvoiceWithItemsGetDto> UpdateInvoiceNo_Async(string invoiceNo, string newInvoiceNo);

    // Update (Invoice + Invoice Items), ** need to update to both Invoice + Invoice Items
    Task<InvoiceWithItemsGetDto> UpdateInvoice_ById_Async(string invoiceNo, InvoiceWithItemsUpdateDto dto);

    // Delete (Invoice + Invoice Items) by InvoiceNo
    // After delete, need to return deleted Invoice Items too or just Invoice ???
    // Task<SaleInvoiceGetDto> DeleteInvoiceAsync(string invoiceNo);
    // Task<InvoiceWithItemsGetDto> Delete_ById_Async(string invoiceNo);
    Task<bool> Delete_ById_Async(string invoiceNo);

    Task<List<InvoiceItemGetDto>> DeleteAllInvoiceItems_ByInvoiceNo_Async(string invoiceNo);



    // =============== OBSOLETED =============================================
    // ** master => TransactionSales + TransactionSalesItem
    [Obsolete("This method is deprecated. Use SaveWithItemsAsync instead.", false)]
    Task<InvoiceWithItemsGetDto> CreateTransactionSaleMasterAsync(InvoiceWithItemsCreateDto dto);
    [Obsolete("This method is deprecated. Use SaveWithItemsAsync instead.", false)]
    Task<InvoiceWithItemsGetDto> CreateSaleInvoiceWithItemsAsync(InvoiceWithItemsCreateDto dto);
    [Obsolete("This method is deprecated. Use FindAllWithItemsByTypeAsync instead.", false)]
    Task<List<InvoiceWithItemsGetDto>> GetSaleInvoiceWithItemsBySalesTypeAsync(string salesType);
    // TransactionSalesGetDto SaveTransactionSale(TransactionSalesMasterCreateDto dto);
    [Obsolete("This method is deprecated. Use FindAllWithItemsByTypeAsync instead.", false)]
    Task<List<InvoiceWithItemsGetDto>> GetTransactionSalesMasterBySalesTypeAsync(string salesType);
    // **single => TransactionSales (no child sale items)
    [Obsolete("This method is deprecated. Use FindAllByTypeAsync instead.", false)]
    Task<List<InvoiceGetDto>> GetTransactionSalesBySalesTypeAsync(string salesType);

}
