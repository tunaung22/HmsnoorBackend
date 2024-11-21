using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.QueryRepositories.Interfaces;

public interface IItemQueryRepository
{
    List<ItemWithDetailAndCurrencyGetDto>? FindAllWithDetails();
    ItemWithDetailAndCurrencyGetDto? FindWithDetailsById(string itemType, string itemNo);

    IQueryable<ItemWithDetailAndCurrencyGetDto> FindAllWithDetailsQuery();
    IQueryable<ItemWithDetailAndCurrencyGetDto?> FindWithDetailsByIdQuery(string itemType, string itemNo);

}
