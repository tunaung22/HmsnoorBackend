namespace HmsnoorBackend.Dtos.Core;

public interface IBasePagingDTO<T>
{
    int TotalRecords { get; set; }
    int CurrentPage { get; set; }
    int TotalPages { get; set; }
    public string PreviousPage { get; set; }
    public string NextPage { get; set; }
    List<T> Content { get; set; }
}
