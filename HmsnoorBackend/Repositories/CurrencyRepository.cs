using HmsnoorBackend.Data;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using HmsnoorBackend.Repositories.Interfaces;

namespace HmsnoorBackend.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly HmsnoorDbContext _context;

    public CurrencyRepository(HmsnoorDbContext context)
    {
        _context = context;
    }


    public IQueryable<Currency> FindAll()
    {
        // var query = _context.Currency;
        var query = _context.Currency
            .OrderBy(c => c.CurrencyId)
            .Select(c => new Currency
            {
                CurrencyId = c.CurrencyId,
                CurrencyDescription = c.CurrencyDescription,
                CurrencyNotation = c.CurrencyNotation
            });

        return query;
    }


    public IQueryable<Currency?> FindById(int currencyId)
    {
        var query = _context.Currency
                .Where(e => e.CurrencyId == currencyId)
                .Select(e => new Currency
                {
                    CurrencyId = e.CurrencyId,
                    CurrencyDescription = e.CurrencyDescription
                });

        return query;
    }

    public IQueryable<Currency?> FindByDescription(string description)
    {
        var query = _context.Currency
            .Where(e => e.CurrencyDescription == description);
        return query;
    }


    public async Task<int> SaveAsync(Currency entity)
    {
        await _context.Currency.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateByIdAsync(int currencyId, Currency entity)
    {
        Currency? currency = await FindById(currencyId).SingleOrDefaultAsync();

        if (currency != null)
        {
            _context.Entry(currency).State = EntityState.Modified;

            currency.CurrencyNotation = entity.CurrencyNotation;
            currency.CurrencyDescription = entity.CurrencyDescription;

            return await _context.SaveChangesAsync() > 0;
        }

        throw new HmsCurrencyNotFoundException($"Currency with id {currencyId} does not exist.");
    }

    public async Task<bool> DeleteByIdAsync(int currencyId)
    {
        Currency? currency = await FindById(currencyId).SingleOrDefaultAsync();
        if (currency != null)
        {
            _context.Currency.Remove(currency);
            return await _context.SaveChangesAsync() > 0;
        }

        throw new HmsCurrencyNotFoundException($"Currency with id {currencyId} does not exist.");
    }


}
