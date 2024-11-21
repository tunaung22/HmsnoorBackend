using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.QueryRepositories.Interfaces;

public interface IItemQueryRepository
{
    List<ItemWithDetailGetDto>? FindAllWithDetails();
    ItemWithDetailGetDto? FindWithDetailsById(string itemType, string itemNo);

    IQueryable<ItemWithDetailGetDto> FindAllWithDetailsQuery();
    IQueryable<ItemWithDetailGetDto?> FindWithDetailsByIdQuery(string itemType, string itemNo);

}
