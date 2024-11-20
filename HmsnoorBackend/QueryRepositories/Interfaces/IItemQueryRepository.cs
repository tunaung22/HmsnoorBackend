using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.QueryRepositories.Interfaces;

public interface IItemQueryRepository
{
    List<ItemWithDetailAndCurrencyGetDto>? FindAllWithDetails();

}
