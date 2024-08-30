namespace LinkEcommerce.Services.Catalogs.Dtos;

public record PaginationRequest(int pageSize = 10, int PageIndex = 10) : BaseRequest;