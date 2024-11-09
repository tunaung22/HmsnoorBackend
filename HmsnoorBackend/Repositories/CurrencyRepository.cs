using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly HmsnoorDbContext _context;

    public CurrencyRepository(HmsnoorDbContext context)
    {
        _context = context;
    }

    public IQueryable<Currency> FindById(int currencyId)
    {
        var query = _context.Currency
                .Where(e => e.CurrencyId == currencyId)
                .Select(e => new Currency
                {
                    CurrencyId = e.CurrencyId,
                    CurrencyName = e.CurrencyName
                });
        return query;
    }
}
