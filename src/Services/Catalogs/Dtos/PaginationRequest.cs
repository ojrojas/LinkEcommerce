namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationRequest(int pageSize = 10, int PageIndex = 10) : BaseRequest;

public record PaginationByNamesRequest : PaginationRequest
{
    public required string Names { get; set; }
}

public record PaginationByBrandIdRequest : PaginationRequest
{
    public Guid BrandId { get; set; }
}

public record PaginationByBrandIdAndTypeIdRequest : PaginationByBrandIdRequest
{
    public Guid TypeId { get; set; }
}
