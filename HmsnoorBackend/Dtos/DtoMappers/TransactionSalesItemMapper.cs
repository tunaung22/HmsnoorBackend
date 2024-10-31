using System;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public class TransactionSalesItemMapper
{

    public static List<TransactionSalesItemGetDto> ToGetDto(List<TransactionSalesItem> items)
    {
        return items.Select(ToGetDto).ToList();
    }


    public static TransactionSalesItemGetDto ToGetDto(TransactionSalesItem e)
    {
        return new TransactionSalesItemGetDto
        {
            InvoiceNo = e.InvoiceNo,
            ItemNo = e.ItemNo,
            ItemName = e.ItemName!,
            Price = e.Price,
            Quantity = e.Quantity,
            Amount = e.Amount
        };
    }

    public static TransactionSalesItem ToEntity(TransactionSalesItemGetDto dto)
    {
        return new TransactionSalesItem
        {
            InvoiceNo = dto.InvoiceNo,
            ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Amount = dto.Amount
        };
    }

    public static TransactionSalesItem ToEntity(TransactionSalesItemCreateDto dto)
    {
        return new TransactionSalesItem
        {
            InvoiceNo = dto.InvoiceNo,
            ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Amount = dto.Amount
        };
    }
}
