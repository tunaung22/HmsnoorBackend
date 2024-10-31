using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Repositories;

public interface IItemHeaderRepository
{
    Task<List<ItemHeaderGetDto>> GetAllItemHeadersAsync();

    Task<ItemHeaderGetDto?> GetItemHeaderByItemNoAsync(string itemNo);

    Task<ItemHeaderGetDto> SaveItemHeaderAsync(ItemHeaderCreateDto data);
}
