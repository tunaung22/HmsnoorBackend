using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Interfaces.QueryRepositories;

public interface IItemQueryRepository
{
    List<ItemWithDetailAndCurrencyGetDto>? FindAllWithDetails();

}
