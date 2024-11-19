using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public class SaleInvoiceItemMapper
{

    /// <summary>
    /// TransactionSalesItem => InvoiceItemGetDto List
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static List<InvoiceItemGetDto> ToGetDto(List<TransactionSalesItem> entity)
    {
        return entity.Select(ToGetDto).ToList();
    }


    public static InvoiceItemGetDto ToGetDto(TransactionSalesItem entity)
    {
        return new InvoiceItemGetDto
        {
            InvoiceNo = entity.InvoiceNo,
            ItemNo = entity.ItemNo,
            ItemName = entity.ItemName!,
            Price = entity.Price,
            Quantity = entity.Quantity,
            Amount = entity.Amount
        };
    }

    /// <summary>
    /// InvoiceWithItemsCreateDto => InvoiceItemCreateDto List
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static List<InvoiceItemCreateDto> ToCreateDto(InvoiceWithItemsCreateDto dto)
    {
        List<InvoiceItemCreateDto> list = [];

        if (dto.SaleItems != null)
        {
            foreach (var item in dto.SaleItems)
            {
                list.Add(new InvoiceItemCreateDto
                {
                    InvoiceNo = item.InvoiceNo,
                    ItemNo = item.ItemNo,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Amount = item.Amount
                });
            }
        }

        return list;
    }

    public static TransactionSalesItem ToEntity(InvoiceItemGetDto dto)
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

    // InvoiceItemUpdateDto => TransactionSalesItem
    public static TransactionSalesItem ToEntity(InvoiceItemUpdateDto dto)
    {
        return new TransactionSalesItem
        {
            // InvoiceNo = dto.SaleItems,
            // ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Amount = dto.Amount
        };
    }

    /// <summary>
    /// InvoiceItemCreateDto => TransactionSalesItem
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static TransactionSalesItem ToEntity(InvoiceItemCreateDto dto)
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



    // InvoiceWithItemsUpdateDto => List<TransactionSalesItem>
    public static List<TransactionSalesItem> ToEntity(InvoiceWithItemsUpdateDto dto)
    {
        List<TransactionSalesItem> itemsList = [];

        if (dto.SaleItems != null)
        {
            dto.SaleItems.ForEach(i =>
            {
                itemsList.Add(new TransactionSalesItem
                {
                    InvoiceNo = i.InvoiceNo,
                    ItemNo = i.ItemNo,
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Amount = i.Amount
                });
            });
        }

        return itemsList;
    }
}
