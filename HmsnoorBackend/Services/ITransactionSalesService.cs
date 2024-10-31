using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services;

public interface ITransactionSalesService
{
    // ** master => TransactionSales + TransactionSalesItem
    Task<TransactionSalesMasterGetDto> CreateTransactionSaleMasterAsync(TransactionSalesMasterCreateDto dto);
    Task<TransactionSalesMasterGetDto> CreateSaleInvoiceWithItemsAsync(TransactionSalesMasterCreateDto dto);

    Task<List<TransactionSalesMasterGetDto>> GetSaleInvoiceWithItemsBySalesTypeAsync(string salesType);

    // TransactionSalesGetDto SaveTransactionSale(TransactionSalesMasterCreateDto dto);
    Task<List<TransactionSalesMasterGetDto>> GetTransactionSalesMasterBySalesTypeAsync(string salesType);
    // **single => TransactionSales (no child sale items)
    Task<List<TransactionSalesGetDto>> GetTransactionSalesBySalesTypeAsync(string salesType);


}
