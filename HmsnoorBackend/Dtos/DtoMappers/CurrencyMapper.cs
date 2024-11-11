using System;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class CurrencyMapper
{
    public static CurrencyGetDto ToGetDto(Currency e)
    {
        return new CurrencyGetDto
        {
            CurrencyId = e.CurrencyId,
            CurrencyDescription = e.CurrencyDescription,
            CurrencyNotation = e.CurrencyNotation,
        };
    }

    public static List<CurrencyGetDto> ToGetDto(List<Currency> e)
    {
        return e.Select(ToGetDto).ToList();
    }

    public static Currency ToEntity(CurrencyCreateDto dto)
    {
        return new Currency
        {
            CurrencyId = dto.CurrencyId,
            CurrencyDescription = dto.CurrencyDescription,
            CurrencyNotation = dto.CurrencyNotation
        };
    }

    public static Currency ToEntity(CurrencyUpdateDto dto)
    {
        return new Currency
        {
            CurrencyDescription = dto.CurrencyDescription,
            CurrencyNotation = dto.CurrencyNotation
        };
    }
}
