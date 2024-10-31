using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services;

public interface IItemHeaderService
{

    Task<List<ItemHeaderGetDto>> GetAllItemHeadersAsync();

    Task<ItemHeaderGetDto> GetItemHeaderByItemNoAsync(string itemNo);

    Task<ItemHeaderGetDto> SaveItemHeaderAsync(ItemHeaderCreateDto requestBody);
}
