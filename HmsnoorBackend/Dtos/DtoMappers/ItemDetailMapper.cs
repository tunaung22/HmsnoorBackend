using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class ItemDetailMapper
{

    public static List<ItemDetailGetDto> ToGetDto(List<ItemDetail> entityList)
    {
        // List<entity> -> List<GetDTO>
        return entityList.Select(ToGetDto).ToList();
    }


    public static ItemDetailGetDto ToGetDto(ItemDetail entity)
    {
        // Entity -> GetDTO
        return new ItemDetailGetDto
        {
            Id = entity.Id,
            ItemNo = entity.ItemNo,
            ItemType = entity.ItemType,
            CurrencyId = entity.CurrencyId,
            Price = entity.Price,
        };
    }


    public static ItemDetail ToEntity(ItemDetailGetDto dto)
    {
        // GetDTO -> Entity
        return new ItemDetail
        {
            Id = dto.Id,
            ItemNo = dto.ItemNo,
            ItemType = dto.ItemType,
            CurrencyId = dto.CurrencyId,
            Price = dto.Price,
        };
    }

    // ItemDetailCreateDto -> ItemDetail
    public static ItemDetail ToEntity(ItemDetailCreateDto dto)
    {
        // CreateDTO -> Entity
        return new ItemDetail
        {
            Id = dto.Id,
            ItemNo = dto.ItemNo,
            ItemType = dto.ItemType,
            CurrencyId = dto.CurrencyId,
            Price = dto.Price,
        };
    }
}
