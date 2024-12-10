using System;

namespace HmsnoorBackend.Dtos.Core;

public class BasePagingDTO<T>
{
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public string PreviousPage { get; set; } = string.Empty;
    public string NextPage { get; set; } = string.Empty;
    public List<T> Content { get; set; } = [];
}
