using System;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class ItemHeaderMapper
{

    public static List<ItemHeaderGetDto> ToGetDtoList(List<ItemHeader> itemList)
    {
        return itemList.Select(ToGetDto).ToList();
    }

    public static ItemHeaderGetDto ToGetDto(ItemHeader e)
    {
        return new ItemHeaderGetDto
        {
            ItemNo = e.ItemNo,
            ItemName = e.ItemName,
            ItemType = e.ItemType,
            ItemCategory = e.ItemCategory,
            MItemName = e.MItemName
        };
    }

    public static ItemHeaderGetDto ToGetDto(List<ItemHeader> e)
    {
        return new ItemHeaderGetDto
        {
        };
    }

    public static ItemHeader ToEntity(ItemHeaderGetDto dto)
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

    public static ItemHeader ToEntity(ItemHeaderCreateDto dto)
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
}