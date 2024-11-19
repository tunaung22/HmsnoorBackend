using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Interfaces.Services;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ILogger<ItemsController> _logger;
    private readonly IItemService _itemService;

    public ItemsController(ILogger<ItemsController> logger, IItemService service)
    {
        _logger = logger;
        _itemService = service;
    }

    [HttpPost("/v1/items")]
    [ProducesResponseType<ItemWithDetailGetDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create_ItemWithDetail_Async([FromBody] ItemWithDetailCreateDto requestBody)
    {
        var result = await _itemService.SaveItemAsync(requestBody);

        if (result != null)
        {
            return Ok(result);
        }

        throw new Exception("Controller::POST: exception occured.");
    }

    [HttpPatch("/v1/items/type/{itemType}/code/{itemNo}")]
    [ProducesResponseType<ItemWithDetailGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Update_ItemWithDetail_Async(string itemType,
                                                            string itemNo,
                                                            ItemWithDetailUpdateDto requestBody)
    {
        var result = await _itemService.UpdateItemByIdAsync(itemType, itemNo, requestBody);

        if (result != null)
        {
            return Ok(result);
        }
        // 400, 500
        throw new Exception("Controller::PATCH: exception occured.");
    }

    [HttpDelete("/v1/items/type/{itemType}/code/{itemNo}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Delete_Item_ById_(string itemType, string itemNo)
    {
        // check for deletable???
        // var result = await _itemService.DeleteItem_ById_Async(itemType, itemNo);
        // if (result)
        // {
        return NoContent();
        // }
        // 400, 500
        // throw new Exception("Controller::DELETE: exception occured.");
    }

    [HttpGet("/v1/items/type/{itemType}/code/{itemNo}")]
    [ProducesResponseType<ItemWithDetailGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItemByIdAsync(string itemType, string itemNo)
    {
        var result = await _itemService.FindItemByIdAsync(itemType, itemNo);

        // if (!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        // if (result == null)
        // {
        // return NotFound(new { Message = "Item Not Found" });
        // return NotFound(new { Message = "Item Not Found" });

        // }


        return Ok(result);
    }

    [HttpGet("/items")]
    [ProducesResponseType<IEnumerable<ItemWithDetailGetDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetItemsAsync()
    {
        // TODOs: pagination, filters
        var result = await _itemService.FindAllItemsAsync();
        return Ok(result);
    }

    [HttpGet("/v1.0/items")]
    [ProducesResponseType<IEnumerable<ItemWithDetailAndCurrencyGetDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get_ItemsWithCurrency_V1_1_Async()
    {
        // TODOs: pagination, filters
        var result = await Task.Run(() => _itemService.FindAllItemsWithDetails());

        return Ok(result);
    }

    // Item Header only
    // [HttpPost("")]
    // public async Task<IActionResult> SaveItemHeaderAsync([FromBody] ItemCreateDto requestBody)
    // {
    //     var result = await _itemService.SaveAsync(requestBody);

    //     if (result != null)
    //     {
    //         return Ok(result);
    //     }

    //     throw new Exception("Controller::POST: exception occured.");
    // }

    // [HttpPatch("{itemType}/{itemNo}")]
    // public async Task<IActionResult> UpdateItemHeaderAsync(string itemType, string itemNo, ItemUpdateDto requestBody)
    // {
    //     var result = await _itemService.UpdateByIdAsync(itemType, itemNo, requestBody);

    //     if (result != null)
    //     {
    //         return Ok(result);
    //     }
    //     // 400, 500
    //     throw new Exception("Controller::PATCH: exception occured.");
    // }

    // [HttpDelete("{itemType}/{itemNo}")]
    // public async Task<IActionResult> DeleteItemHeaderAsync(string itemType, string itemNo)
    // {
    //     var result = await _itemService.DeleteByIdAsync(itemType, itemNo);

    //     if (result)
    //     {
    //         return NoContent();
    //     }
    //     // 400, 500
    //     throw new Exception("Controller::DELETE: exception occured.");
    // }

    // [HttpGet("{itemType}/{itemNo}")]
    // public async Task<IActionResult> GetItemByItemNoAndItemTypeAsync(string itemType, string itemNo)
    // {
    //     // var result = await _service.GetItemHeaderByItemNoAsync(itemNo);
    //     var result = await _itemService.FindByIdAsync(itemType, itemNo);

    //     if (result == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(result);
    // }

    // [HttpGet("")]
    // [ProducesResponseType<ItemWithDetailGetDto>(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<IActionResult> GetAllItemsAsync()
    // {
    //     // TODOs: pagination, filters
    //     // var result = await _service.GetAllItemHeadersAsync();
    //     var result = await _itemService.FindAllAsync();
    //     return Ok(result);
    // }

}
