using Npgsql.Replication;

namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationRequest(int pageSize = 10, int PageIndex = 10) : BaseRequest
{
    public int PageSize { get; set; } = pageSize;
    public int PageIndex {get;set;} = PageIndex;
}

public record PaginationByNamesRequest(string name, int pageSize, int pageIndex) : PaginationRequest(pageSize, pageIndex)
{  
    public string Names { get; set; } = name;
}

public record PaginationByBrandIdRequest(Guid brandId, int pageSize, int pageIndex) : PaginationRequest(pageSize, pageIndex)
{
    public Guid BrandId { get; set; }= brandId;
}

public record PaginationByBrandIdAndTypeIdRequest(Guid typeId, Guid brandId, int pageSize, int pageIndex) : PaginationByBrandIdRequest(brandId, pageSize, pageIndex)
{
    public Guid TypeId { get; set; } = typeId;
}
