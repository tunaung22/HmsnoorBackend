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
            CurrencyName = e.CurrencyName
        };
    }
}
