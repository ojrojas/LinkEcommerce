namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        return api;
    }
}