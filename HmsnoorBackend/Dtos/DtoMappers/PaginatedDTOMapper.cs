using System;
using System.Web;
using HmsnoorBackend.Dtos.Core;
using HmsnoorBackend.Dtos.SaleInvoices;
using Microsoft.AspNetCore.Http.Extensions;

namespace HmsnoorBackend.Dtos.DtoMappers;

/* DOTO Mapper
    input:  HttpRequest request
            IQueryable<T>?,
            int totalCount, 
            int pageNumber, 
            int pageSize, 
*/
public static class PaginatedDTOMapper
{
    // public static TResult Paginate<TResult, TQuery>(
    //     List<TQuery>? queryResult,
    //     HttpRequest request,
    //     int totalCount,
    //     int pageNumber,
    //     int pageSize) where TQuery : class where TResult : class, new()
    // {
    //     return new TResult()
    //     {
    //         // TotalRecords = totalCount,
    //         // TotalPages = pageSize,
    //         // CurrentPage = pageNumber,
    //         // PreviousPage = "",
    //         // NextPage = "",
    //         // Content = queryResult ?? []
    //     };
    // }

    public static BasePagingDTO<T> CreatePagingDTO<T>(
        List<T>? queryResult,
        HttpRequest request,
        int totalCount,
        int pageNumber,
        int pageSize) where T : class
    {
        // ========== Prepare URLs ===============
        int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
        Uri? uri = new(request.GetDisplayUrl());
        var queryParams = HttpUtility.ParseQueryString(uri.Query);
        var previousPageUrl = string.Empty;
        var nextPageUrl = string.Empty;

        if (queryParams.Count > 0)
        {
            if (pageNumber <= 1)
            { // is: first page (no previous, has next)
                var uriBuilder = new UriBuilder(uri)
                { Query = $"pageSize={pageSize}&pageNumber={pageNumber + 1}" };

                nextPageUrl = uriBuilder.ToString();
            }
            else if (pageNumber == totalPages)
            { // is: last page, (has previous, no next)
                var uriBuilder = new UriBuilder(uri)
                { Query = $"pageSize={pageSize}&pageNumber={pageNumber - 1}" };

                previousPageUrl = uriBuilder.ToString();
            }
            else
            { // is middle, (has previous, has next)
                var previousPageUriBuilder = new UriBuilder(uri)
                { Query = $"pageSize={pageSize}&pageNumber={pageNumber - 1}" };

                previousPageUrl = previousPageUriBuilder.ToString();

                var nextPageUriBuilder = new UriBuilder(uri)
                { Query = $"pageSize={pageSize}&pageNumber={pageNumber + 1}" };

                nextPageUrl = nextPageUriBuilder.ToString();
            }
        }

        return new BasePagingDTO<T>()
        {
            TotalRecords = totalCount,
            TotalPages = totalPages,
            CurrentPage = pageNumber,
            PreviousPage = previousPageUrl,
            NextPage = nextPageUrl,
            Content = queryResult ?? []
        };
    }
}



