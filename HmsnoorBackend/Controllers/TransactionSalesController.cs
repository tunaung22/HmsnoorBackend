using System;
using System.ComponentModel.DataAnnotations;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace HmsnoorBackend.Controllers;

[Route("api/sales")]
[ApiController]
public class TransactionSalesController : ControllerBase
{

    private readonly TransactionSalesService _service;

    public TransactionSalesController(TransactionSalesService service)
    {
        _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllSales([FromQuery(Name = "type")] string salesType)
    {
        // if (string.IsNullOrEmpty(salesType))
        // {
        //     Log.Information("Throw ArgumentException here....");
        //     throw new ArgumentException("Query parameter 'type' is required.", nameof(salesType));
        // }
        try
        {
            var result = await _service.GetTransactionSalesMasterBySalesTypeAsync(salesType);

            return Ok(result);

        }
        catch (Exception e)
        {
            Log.Error("Exception: {e}", e);
            throw;
        }

    }


    [HttpPost("")]
    public async Task<IActionResult> CreateSale([FromBody] TransactionSalesMasterCreateDto requestBody)
    {
        var result = await _service.CreateSaleInvoiceWithItemsAsync(requestBody);
        return Ok(result);

    }




    // url param
    // [HttpGet("{salesType}")]
    // public async Task<IActionResult> GetSales(string salesType)
}
