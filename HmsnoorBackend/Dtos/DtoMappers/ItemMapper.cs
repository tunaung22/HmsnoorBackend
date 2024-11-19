using System;
using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class ItemMapper
{

    public static List<ItemGetDto> ToGetDtoList(List<ItemHeader> itemList)
    {
        return itemList.Select(ToGetDto).ToList();
    }


    public static ItemGetDto ToGetDto(ItemHeader e)
    {
        return new ItemGetDto
        {
            ItemNo = e.ItemNo,
            ItemName = e.ItemName,
            ItemType = e.ItemType,
            ItemCategory = e.ItemCategory,
            MItemName = e.MItemName
        };
    }

    public static List<ItemDetailGetDto> ToGetDtoList(List<ItemDetail> e)
    {
        List<ItemDetailGetDto> result = [];

        e.ForEach(i =>
        {
            result.Add(new ItemDetailGetDto
            {
                Id = i.Id,
                ItemType = i.ItemType,
                ItemNo = i.ItemNo,
                CurrencyId = i.CurrencyId,
                Price = i.Price
            });
        });

        return result;
    }





    public static ItemGetDto ToGetDto(List<ItemHeader> e)
    {
        return new ItemGetDto
        {
        };
    }

    public static ItemHeader ToEntity(ItemGetDto dto)
    {
        return new ItemHeader
        {
            ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            ItemType = dto.ItemType,
            ItemCategory = dto.ItemCategory,
            MItemName = dto.MItemName
        };
    }

    public static ItemHeader ToEntity(ItemUpdateDto dto)
    {
        return new ItemHeader
        {
            // ItemNo = dto.ItemNo,
            // ItemType = dto.ItemType,
            ItemName = dto.ItemName,
            ItemCategory = dto.ItemCategory,
            MItemName = dto.MItemName
        };
    }

    public static ItemHeader ToEntity(ItemCreateDto dto)
    {
        return new ItemHeader
        {
            ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            ItemType = dto.ItemType,
            ItemCategory = dto.ItemCategory,
            MItemName = dto.MItemName
        };
    }

    /// <summary>
    /// Item with Details CREATE DTO
    ///     to
    /// ItemHeader
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static ItemHeader ToItemHeaderEntity(ItemWithDetailCreateDto dto)
    {
        return new ItemHeader
        {
            ItemNo = dto.ItemNo,
            ItemName = dto.ItemName,
            ItemType = dto.ItemType,
            ItemCategory = dto.ItemCategory,
            MItemName = dto.MItemName
        };
    }


    /// <summary>
    /// Item with Details CREATE DTO
    ///     to
    /// List of ItemDetail
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static List<ItemDetail> ToItemDetailEntityList(ItemWithDetailCreateDto dto)
    {
        List<ItemDetail> result = [];

        dto.ItemDetails.ForEach(i =>
        {
            result.Add(new ItemDetail
            {
                CurrencyId = i.CurrencyId,
                Price = i.Price
            });
        });

        return result;
    }
}