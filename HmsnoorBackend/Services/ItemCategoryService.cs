using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Repositories.Interfaces;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class ItemCategoryService : IItemCategoryService
{
    private readonly ILogger<ItemCategoryService> _logger;
    private readonly IItemCategoryRepository _itemCategoryRepo;

    public ItemCategoryService(
        ILogger<ItemCategoryService> logger,
        IItemCategoryRepository itemCategoryRepo)
    {
        _logger = logger;
        _itemCategoryRepo = itemCategoryRepo;
    }

    public async Task<ItemCategoryGetDto> Save_ItemCategory_Async(ItemCategoryCreateDto createDto)
    {
        try
        {
            var itemCategory = ItemCategoryMapper.ToEntity(createDto);
            var query = await _itemCategoryRepo.SaveAsync(itemCategory);
            if (query > 0)
            {
                // QUERY inserted record
                var newCategory = await _itemCategoryRepo
                    .FindById(createDto.ItemCategoryId)
                    .SingleOrDefaultAsync();
                if (newCategory != null)
                {
                    return ItemCategoryMapper.ToGetDto(newCategory);
                }

                throw new Exception("Unexpected exception occured: failed to retrieve created object.");
            }

            // FAIL
            throw new Exception("INSERT Item Category FAILED");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_ItemCategory_Async), e);
            throw;
        }
    }

    public async Task<ItemCategoryGetDto> Update_ItemCategory_Async(
        string itemCategoryId,
        ItemCategoryUpdateDto updateDto)
    {
        try
        {
            var categoryDto = await Find_ById_Async(itemCategoryId);
            var category = ItemCategoryMapper.ToEntity(updateDto);

            var updatedCategory = await _itemCategoryRepo
                .UpdateByIdAsync(itemCategoryId, category);
            if (updatedCategory > 0)
            {
                // QUERY updated record
                var newCategory = await _itemCategoryRepo
                    .FindById(itemCategoryId)
                    .SingleOrDefaultAsync();
                if (newCategory != null)
                {
                    return ItemCategoryMapper.ToGetDto(newCategory);
                }

                throw new Exception("Unexpected exception occured: failed to retrieve updated object.");
            }

            throw new Exception($"Exception: Failed to update item category {itemCategoryId}!");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}",
                                nameof(Update_ItemCategory_Async), e);
            throw;
        }
    }
    public async Task<bool> Delete_ItemCategory_Async(string itemCategoryId)
    {
        try
        {
            var categoryDto = await Find_ById_Async(itemCategoryId);

            return await _itemCategoryRepo
                .DeleteByIdAsync(itemCategoryId) > 0;

            // throw new Exception($"Exception: Failed to delete currency {itemCategoryId}");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Delete_ItemCategory_Async), e);
            throw;
        }
    }



    public async Task<ItemCategoryGetDto?> Find_ById_Async(string itemCategoryId)
    {
        try
        {
            ItemCategory? category = await _itemCategoryRepo
                .FindById(itemCategoryId)
                .SingleOrDefaultAsync();

            if (category != null)
                return ItemCategoryMapper.ToGetDto(category);

            return null;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Find_ById_Async), e);
            throw;
        }
    }

    public async Task<List<ItemCategoryGetDto>> FindAll_ItemCategory_Async()
    {
        try
        {
            List<ItemCategory> categories = await _itemCategoryRepo
                .FindAll()
                .ToListAsync();
            if (categories.Count > 0)
                return ItemCategoryMapper.ToGetDto(categories);

            return [];
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(FindAll_ItemCategory_Async), e);

            throw;
        }
    }
}

