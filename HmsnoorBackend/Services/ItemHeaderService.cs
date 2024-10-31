using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Repositories;

namespace HmsnoorBackend.Services;

public class ItemHeaderService: IItemHeaderService
{

    private readonly IItemHeaderRepository _repo;

    public ItemHeaderService(IItemHeaderRepository repository)
    {
        _repo = repository;
    }

    public async Task<List<ItemHeaderGetDto>> GetAllItemHeadersAsync()
    {
        var result = await _repo.GetAllItemHeadersAsync();

        return result;
    }

    public async Task<ItemHeaderGetDto> GetItemHeaderByItemNoAsync(string itemNo)
    {
        var result = await _repo.GetItemHeaderByItemNoAsync(itemNo);
        return result;
    }

    public async Task<ItemHeaderGetDto> SaveItemHeaderAsync(ItemHeaderCreateDto requestBody)
    {
        return await _repo.SaveItemHeaderAsync(requestBody);

    }
}
