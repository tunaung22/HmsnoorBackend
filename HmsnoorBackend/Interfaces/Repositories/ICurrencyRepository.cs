using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Interfaces.Repositories;

public interface ICurrencyRepository
{

    IQueryable<Currency> FindAll();
    IQueryable<Currency?> FindById(int currencyId);
    IQueryable<Currency?> FindByDescription(string description);
    Task<int> SaveAsync(Currency entity);
    Task<bool> UpdateByIdAsync(int currencyId, Currency entity);
    Task<bool> DeleteByIdAsync(int currencyId);
}
