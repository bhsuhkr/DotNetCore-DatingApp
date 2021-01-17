using System.Text.Json;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse respose, int currentPage, int itemPerPage, int totalItems, int totalPages)        
        {
            var paginationHeader = new PaginationHeader(currentPage, itemPerPage, totalItems, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            respose.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            respose.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}