using System;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api/items")]
[ApiController]
public class ItemHeaderController : ControllerBase
{

    private readonly ILogger<ItemHeaderController> _logger;
    private readonly ItemHeaderService _service;

    public ItemHeaderController(ILogger<ItemHeaderController> logger, ItemHeaderService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItemHeaders()
    {
        var result = await _service.GetAllItemHeadersAsync();
        return Ok(result);
    }

    [HttpGet("{itemNo}")]
    public async Task<IActionResult> GetItemHeaderByItemNo(string itemNo)
    {
        var result = await _service.GetItemHeaderByItemNoAsync(itemNo);
        return Ok(result);

    }



    [HttpPost]
    public async Task<IActionResult> SaveItemHeader([FromBody] ItemHeaderCreateDto request)
    {
        var result = await _service.SaveItemHeaderAsync(request);
        if (result != null)
        {
            return Ok(result);
        }
        throw new Exception("Controller: exception occured.");
    }
}
