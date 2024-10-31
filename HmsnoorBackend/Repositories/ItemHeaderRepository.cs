using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HmsnoorBackend.Repositories;

public class ItemHeaderRepository : IItemHeaderRepository
{

    private readonly HmsnoorDbContext _context;
    private readonly ILogger<ItemHeaderRepository> _logger;

    public ItemHeaderRepository(HmsnoorDbContext ctx, ILogger<ItemHeaderRepository> logger)
    {
        _context = ctx;
        _logger = logger;
    }


    public async Task<List<ItemHeaderGetDto>> GetAllItemHeadersAsync()
    {
        // LINQ
        var itemHeaders = await _context.ItemHeaders
            .OrderBy(i => i.ItemNo)
            .Select(i => new ItemHeaderGetDto()
            {
                ItemNo = i.ItemNo,
                ItemName = i.ItemName,
                ItemType = i.ItemType,
                ItemCategory = i.ItemCategory,
                MItemName = i.MItemName
            })
            .ToListAsync();
        _logger.LogInformation("Item Headers: {itemCount}", itemHeaders.Count);
        Log.Information("Item Headers count: {count}", itemHeaders.Count);
        return itemHeaders;
    }

    public async Task<ItemHeaderGetDto?> GetItemHeaderByItemNoAsync(string itemNo)
    {
        // RAW SQL
        // var itemHeader = await _context.ItemHeaders
        //     .FromSql($"SELECT ItemNo, ItemName, ItemType, ItemCategory, MItemName FROM ItemHeaders WHERE ItemNo={itemNo}")
        //     .SingleAsync();
        // var result = ItemHeaderMapper.ToGetDto(itemHeader);
        // return result;

        // LINQ
        var itemHeader = await _context.ItemHeaders
            .Where(i => i.ItemNo == itemNo)
            .Select(i => new ItemHeaderGetDto
            {
                ItemNo = i.ItemNo,
                ItemName = i.ItemName,
                ItemType = i.ItemType,
                ItemCategory = i.ItemCategory,
                MItemName = i.MItemName
            })
            .FirstOrDefaultAsync();

        return itemHeader;
    }

    public async Task<ItemHeaderGetDto> SaveItemHeaderAsync(ItemHeaderCreateDto data)
    {
        // dto to entity
        var entity = ItemHeaderMapper.ToEntity(data);

        await _context.ItemHeaders
            .AddAsync(entity);
        var result = await _context.SaveChangesAsync();

        if (result > 0)
        {
            // query inserted data
            var createdEntity = await _context.ItemHeaders
                .Where(i => i.ItemNo == data.ItemNo)
                .SingleOrDefaultAsync();
            if (createdEntity != null)
            {
                var createdDto = ItemHeaderMapper.ToGetDto(createdEntity);
                return createdDto;
            }
            throw new InvalidOperationException("Cannot fetch inserted item header.");
        }
        throw new Exception("Exception occured while saving Item Header.");
    }
}



