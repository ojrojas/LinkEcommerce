using Npgsql.Replication;

namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationRequest(int PageSize = 10, int PageIndex = 0) : BaseRequest
{
}

public record PaginationByNamesRequest(string Names, int PageSize=10, int PageIndex=0) : PaginationRequest(PageSize, PageIndex)
{  
    public string Names { get; set; } = Names;
}

public record PaginationByBrandIdRequest(Guid BrandId, int PageSize=10, int PageIndex=0) : PaginationRequest(PageSize, PageIndex)
{
    public Guid BrandId { get; set; }= BrandId;
}

public record PaginationByBrandIdAndTypeIdRequest(Guid TypeId, Guid BrandId, int PageSize=10, int PageIndex=0) : PaginationByBrandIdRequest(BrandId, PageSize, PageIndex)
{
    public Guid TypeId { get; set; } = TypeId;
}
