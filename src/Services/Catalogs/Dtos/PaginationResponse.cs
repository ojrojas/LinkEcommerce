namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationResponse : BaseResponse
{
    public PaginationResponse(Guid correlationId) : base(correlationId)
    {

    }

    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}