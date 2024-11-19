using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Interfaces.Repositories;
using HmsnoorBackend.Interfaces.Services;
using HmsnoorBackend.Middlewares.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class SaleItemService : ISaleItemService
{
    private readonly ISaleItemRepository _saleItemRepo;

    public SaleItemService(ISaleItemRepository repository)
    {
        _saleItemRepo = repository;
    }

    public async Task<List<InvoiceItemGetDto>> FindAllSaleItemsByInvoiceNoAsync(string invoiceNo)
    {
        var q = await _saleItemRepo.FindManyByInvoiceNo(invoiceNo).ToListAsync();
        if (q != null)
            return SaleInvoiceItemMapper.ToGetDto(q);

        throw new HmsSaleInvoiceNotFoundException(invoiceNo);
    }


    [Obsolete("This method is deprecated. Use FindAllSaleItemsByInvoiceNoAsync instead.", false)]
    public async Task<List<InvoiceItemGetDto>> GetAllTransactionSalesItemAsync(string invoiceNo)
    {
        var saleItems = await _saleItemRepo.GetAllSalesItemByInvoiceNoAsync(invoiceNo);
        return SaleInvoiceItemMapper.ToGetDto(saleItems);
    }
}
