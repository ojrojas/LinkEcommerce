namespace LinkEcommerce.Services.Catalogs.Dtos;

public record DeleteCatalogItemResponse : BaseResponse
{
    public DeleteCatalogItemResponse(Guid correlationId) : base(correlationId)
    {

    }

    public bool IsDeleted { get; set; }
}