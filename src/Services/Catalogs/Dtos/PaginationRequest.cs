using Npgsql.Replication;

namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationRequest(int PageSize = 10, int PageIndex = 10) : BaseRequest
{
}

public record PaginationByNamesRequest(string name, int PageSize, int PageIndex) : PaginationRequest(PageSize, PageIndex)
{  
    public string Names { get; set; } = name;
}

public record PaginationByBrandIdRequest(Guid brandId, int PageSize, int PageIndex) : PaginationRequest(PageSize, PageIndex)
{
    public Guid BrandId { get; set; }= brandId;
}

public record PaginationByBrandIdAndTypeIdRequest(Guid typeId, Guid brandId, int PageSize, int PageIndex) : PaginationByBrandIdRequest(brandId, PageSize, PageIndex)
{
    public Guid TypeId { get; set; } = typeId;
}
