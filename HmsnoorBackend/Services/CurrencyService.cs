using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ILogger<CurrencyService> _logger;
    private readonly HmsnoorDbContext _context;
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyService(
        ILogger<CurrencyService> logger,
        HmsnoorDbContext context,
        ICurrencyRepository currencyRepository)
    {
        _logger = logger;
        _context = context;
        _currencyRepository = currencyRepository;
    }


    public async Task<List<CurrencyGetDto>> FindAll_Currency_Async()
    {
        List<CurrencyGetDto> currencyDto = [];
        try
        {
            List<Currency> currencyList = await _currencyRepository
                .FindAll()
                .ToListAsync();
            if (currencyList.Count > 0)
                currencyDto = CurrencyMapper.ToGetDto(currencyList);

            return currencyDto;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_Currency_Async), e);
            throw;
        }
    }

    public async Task<CurrencyGetDto?> Find_ById_Async(int currencyId)
    {
        CurrencyGetDto currencyDto = new();

        try
        {
            Currency? currency = await _currencyRepository
                .FindById(currencyId)
                .FirstOrDefaultAsync();
            if (currency != null)
                currencyDto = CurrencyMapper.ToGetDto(currency);

            return currencyDto;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_Currency_Async), e);
            throw;
        }
    }

    /// <summary>
    /// Save Currency
    /// ** CurrencyDescription and CurrencyNotation 
    ///    are NOT UNIQUE in Database
    ///    NEED TO CHECK UNIQUENESS
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<CurrencyGetDto> Save_Currency_Async(CurrencyCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // ** Should we get created id from Currency Repository
            //     instead of affected rows ???
            // Check Unique (**database table has no uniqueness)
            var currencyDescription = await _currencyRepository
                .FindByDescription(dto.CurrencyDescription)
                .FirstOrDefaultAsync();
            if (currencyDescription != null)
                throw new HmsCurrencyConflictException("Currency already exist.");

            int affectedRows = await _currencyRepository
                .SaveAsync(CurrencyMapper.ToEntity(dto));
            if (affectedRows > 0)
            {
                var currency = await _currencyRepository
                    .FindByDescription(dto.CurrencyDescription)
                    .FirstOrDefaultAsync();
                if (currency != null)
                {
                    CurrencyGetDto currencyDto = CurrencyMapper.ToGetDto(currency);

                    await transaction.CommitAsync();

                    return currencyDto;
                }

                throw new HmsCurrencyInsertFailedException("Failed to fetch saved currency.");
            }

            throw new HmsCurrencyInsertFailedException("Saving new currency failed.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_Currency_Async), e);
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<CurrencyGetDto> Update_Currency_Async(int currencyId, CurrencyUpdateDto dto)
    {
        try
        {
            CurrencyGetDto? currencyDto = await Find_ById_Async(currencyId);

            if (currencyDto != null)
            {
                bool currencyUpdated = await _currencyRepository
                    .UpdateByIdAsync(currencyId, CurrencyMapper.ToEntity(dto));
                if (currencyUpdated)
                {
                    return currencyDto;
                }

                throw new HmsCurrencyUpdateFailedException($"Exception: Failed to update currency {currencyId}!");
            }
            throw new HmsCurrencyNotFoundException($"Currency to update {currencyId} does not exist.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_Currency_Async), e);
            throw;
        }
    }

    public async Task<bool> Delete_Currency_Async(int currencyId)
    {
        try
        {
            CurrencyGetDto? currencyDto = await Find_ById_Async(currencyId);

            if (currencyDto != null)
            {
                return await _currencyRepository
                    .DeleteByIdAsync(currencyId);

                throw new HmsCurrencyDeleteFailedException($"Exception: Failed to delete currency {currencyId}");
            }

            throw new HmsCurrencyNotFoundException($"Currency to delete {currencyId} does not exist.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service: {name} {e}", nameof(Save_Currency_Async), e); throw;
        }
    }
}
