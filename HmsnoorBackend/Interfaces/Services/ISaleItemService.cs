using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Interfaces.Services;

public interface ISaleItemService
{
    Task<List<InvoiceItemGetDto>> FindAllSaleItemsByInvoiceNoAsync(string invoiceNo);


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use FindAllSaleItemsByInvoiceNoAsync instead.", false)]
    Task<List<InvoiceItemGetDto>> GetAllTransactionSalesItemAsync(string invoiceNo);

}
