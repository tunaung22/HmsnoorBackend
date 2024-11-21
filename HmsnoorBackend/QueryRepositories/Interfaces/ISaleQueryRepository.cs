using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.QueryRepositories.Interfaces;

public interface ISaleQueryRepository
{
    IQueryable<InvoiceWithItemsGetDto> FindAllWithdetails();
}
