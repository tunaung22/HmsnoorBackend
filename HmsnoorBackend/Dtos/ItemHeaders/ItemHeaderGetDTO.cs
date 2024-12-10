using System;
using HmsnoorBackend.Dtos.Core;

namespace HmsnoorBackend.Dtos.ItemHeaders;

public class ItemHeaderGetDTO : IBasePagingDTO<ItemWithDetailGetDto>
{
    public int TotalRecords { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string PreviousPage { get; set; } = string.Empty;
    public string NextPage { get; set; } = string.Empty;
    public List<ItemWithDetailGetDto> Content { get; set; } = [];
}
