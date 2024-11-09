using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api/sales")]
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

    [HttpPost("")]
    public async Task<IActionResult> Create_SaleInvoice_Async([FromBody] InvoiceWithItemsCreateDto requestBody)
    {
        var result = await _saleInvoiceService.SaveInvoice_Async(requestBody);
        return Ok(result);
    }

    [HttpPatch("/{invoiceNo}")]
    public async Task<IActionResult> Update_SaleInvoice_ById_Async(string invoiceNo, [FromBody] InvoiceWithItemsUpdateDto reqBody)
    {
        var updatedInvoice = await _saleInvoiceService.UpdateInvoice_ById_Async(invoiceNo, reqBody);
        return Ok(updatedInvoice);
    }

    [HttpDelete("/{invoiceNo}")]
    public async Task<IActionResult> Delete_SaleInvoice_ById_Async(string invoiceNo)
    {
        if (await _saleInvoiceService.Delete_ById_Async(invoiceNo))
        {
            return NoContent();
        }

        // throw new Hmssaleinvoicedelet
        throw new Exception("");
    }

    [HttpGet("")]
    public async Task<IActionResult> Get_All_Async([FromQuery(Name = "type")] string type)
    {
        // if (string.IsNullOrEmpty(HttpContext.Request.Query["type"].ToString()))
        // {
        //     return BadRequest("The 'type' query parameter is required.");
        // }

        var result = await _saleInvoiceService.FindAll_Invoice_Async(type);

        return Ok(result);

        // catch (ArgumentException e)
        //     _logger.LogError("Argument Exception: {e}", e);
        // catch (Exception e)
        //     _logger.LogError("Exception: {e}", e);
    }

    [HttpGet("{invoiceNo}")]
    public async Task<IActionResult> Get_SaleInvoice_Async(string invoiceNo)
    {
        if (string.IsNullOrEmpty(invoiceNo))
            throw new ArgumentNullException("Argument for Sale Invoice is required.");

        var result = await _saleInvoiceService.Find_ById_Async(invoiceNo);

        if (result != null)
            return Ok(result);

        return NotFound();
    }

    // url param
    // [HttpGet("{salesType}")]
    // public async Task<IActionResult> GetSales(string salesType)
}
