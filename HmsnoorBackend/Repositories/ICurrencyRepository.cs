using System;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Repositories;

public interface ICurrencyRepository
{
    IQueryable<Currency> FindById(int currencyId);
}
