using HmsnoorBackend.Dtos.Core;

namespace HmsnoorBackend.Dtos.SaleInvoices;

public class SaleInvoiceGetDTO : IBasePagingDTO<InvoiceWithItemsGetDto>
{
    public int TotalRecords { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string PreviousPage { get; set; } = string.Empty;
    public string NextPage { get; set; } = string.Empty;
    public List<InvoiceWithItemsGetDto> Content { get; set; } = [];

}