using HmsnoorBackend.Dtos;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api/")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly ICurrencyService _currencyService;

    public CurrencyController(
        ILogger<CurrencyController> logger,
        ICurrencyService currencyService)
    {
        _logger = logger;
        _currencyService = currencyService;
    }

    [HttpPost("/v1/currencies")]
    [ProducesResponseType<CurrencyGetDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create_Currency_Async([FromBody] CurrencyCreateDto requestBody)
    {
        if (requestBody != null)
        {
            var result = await _currencyService.Save_Currency_Async(requestBody);
            var uri = Url.Action(nameof(Create_Currency_Async), new { id = result.CurrencyId });

            return Created(uri, result);
        }

        return BadRequest();
    }

    [HttpPatch("/v1/currencies")]
    [ProducesResponseType<CurrencyGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update_Currency_ById_Async(int currencyId, CurrencyUpdateDto requestBody)
    {
        if (currencyId > 0)
        {
            CurrencyGetDto? currencyDto = await _currencyService
                .Find_ById_Async(currencyId);
            if (currencyDto != null)
            {
                CurrencyGetDto updatedCurrencyDto = await _currencyService.Update_Currency_Async(currencyId, requestBody);

                return Ok(updatedCurrencyDto);
            }

            return NotFound();
        }

        return BadRequest();
    }

    [HttpDelete("/v1/currencies")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete_Currency_ById_Async(int currencyId, [FromBody] CurrencyUpdateDto requestBody)
    {
        if (currencyId > 0)
        {
            CurrencyGetDto? result = await _currencyService
                .Find_ById_Async(currencyId);
            if (result != null)
            {
                if (await _currencyService.Delete_Currency_Async(currencyId))
                {
                    return NoContent();
                }

                throw new HmsCurrencyDeleteFailedException($"Failed at deleting currency {currencyId}");
            }

            throw new HmsCurrencyNotFoundException($"Currency id {currencyId} does not exist.");
        }

        throw new ArgumentException("Invalid arguement for currency id");
    }

    [HttpGet("/v1/currencies/{currencyId}")]
    [ProducesResponseType<CurrencyGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get_Currency_byId_Async(int currencyId)
    {
        if (currencyId > 0)
        {
            CurrencyGetDto? result = await _currencyService
                .Find_ById_Async(currencyId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        throw new ArgumentException("Invalid arguement for currency id");
    }

    [HttpGet("/v1/currencies")]
    [ProducesResponseType<IEnumerable<CurrencyGetDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get_AllCurrency_Async()
    {
        var result = await _currencyService
            .FindAll_Currency_Async();
        return Ok(result);
    }

}
