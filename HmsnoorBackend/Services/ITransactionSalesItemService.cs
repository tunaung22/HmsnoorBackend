using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services;

public interface ITransactionSalesItemService
{

    Task<List<TransactionSalesItemGetDto>> GetAllTransactionSalesItemAsync(string invoiceNo);

}
