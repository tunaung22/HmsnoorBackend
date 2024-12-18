using HmsnoorBackend.Data.Models.Filters;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api/")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;
    private readonly ISaleInvoiceService _saleInvoiceService;

    public SalesController(
        ILogger<SalesController> logger,
        ISaleInvoiceService saleInvoiceService)
    {
        _logger = logger;
        _saleInvoiceService = saleInvoiceService;
    }

    [HttpPost("v1/sales")]
    [ProducesResponseType<InvoiceWithItemsGetDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create_SaleInvoice_Async([FromBody] InvoiceWithItemsCreateDto requestBody)
    {
        var result = await _saleInvoiceService.SaveInvoice_Async(requestBody);
        return Ok(result);
    }

    [HttpPatch("v1/sales/{invoiceNo}")]
    [ProducesResponseType<InvoiceWithItemsGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Update_SaleInvoice_ById_Async(string invoiceNo, [FromBody] InvoiceWithItemsUpdateDto reqBody)
    {
        InvoiceWithItemsGetDto? updatedInvoice = await _saleInvoiceService.UpdateInvoice_ById_Async(invoiceNo, reqBody);
        return Ok(updatedInvoice);
    }

    [HttpDelete("v1/sales/{invoiceNo}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete_SaleInvoice_ById_Async(string invoiceNo)
    {
        if (await _saleInvoiceService.Delete_ById_Async(invoiceNo))
        {
            return NoContent();
        }

        // throw new Hmssaleinvoicedelet
        throw new Exception("");
    }

    [HttpGet("v1/sales/{invoiceNo}")]
    [ProducesResponseType<InvoiceWithItemsGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get_SaleInvoice_ById_Async(string invoiceNo)
    {
        if (string.IsNullOrEmpty(invoiceNo))
            throw new ArgumentNullException("Argument for Sale Invoice is required.");

        var result = await _saleInvoiceService.Find_ById_Async(invoiceNo);

        if (result != null)
            return Ok(result);

        return NotFound();
    }

    [HttpGet("v1/sales")]
    [ProducesResponseType<IEnumerable<InvoiceWithItemsGetDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get_All_SaleInvoices(
        [FromQuery] string? saleType,
        [FromQuery] PaginationFilter filter)
    {
        // var result = await _saleInvoiceService
        //     .FindAll_InvoiceWithDetail_Async(
        //         saleType,
        //         new PaginationFilter(filter.PageNumber, filter.PageSize));

        var result = await _saleInvoiceService
            .FindAll_InvoiceWithDetail_Paginated_Async(
                saleType,
                new PaginationFilter(filter.PageNumber, filter.PageSize),
                Request.GetDisplayUrl());

        return Ok(result);
    }



    // url param
    // [HttpGet("{salesType}")]
    // public async Task<IActionResult> GetSales(string salesType)
}
