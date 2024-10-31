using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Repositories;

namespace HmsnoorBackend.Services;

public class TransactionSalesItemService : ITransactionSalesItemService
{
    private readonly ITransactionSalesItemRepository _repo;

    public TransactionSalesItemService(ITransactionSalesItemRepository repository)
    {
        _repo = repository;
    }

    public async Task<List<TransactionSalesItemGetDto>> GetAllTransactionSalesItemAsync(string invoiceNo)
    {
        var saleItems = await _repo.GetAllSalesItemByInvoiceNoAsync(invoiceNo);
        return TransactionSalesItemMapper.ToGetDto(saleItems);
    }
}
