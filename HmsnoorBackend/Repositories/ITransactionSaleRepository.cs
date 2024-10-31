using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Repositories;


public interface ITransactionSaleRepository
{

    Task<TransactionSalesMasterGetDto> CreateTransactionSaleMasterAsync(TransactionSalesMasterCreateDto data);



    Task<TransactionSale> CreateTransactionSale(TransactionSale data);
    Task<TransactionSale> GetTransactionSaleByInvoiceNo(string invoiceNo);
    Task<List<TransactionSale>> GetAllTransactionSalesAsync(string salesType);


}
