namespace LinkEcommerce.Services.Basket.Extensions;

internal static class ServerCallContextIdentityExtension
{
    public static string? GetUserIdentity(this ServerCallContext context) 
    {
        return context.GetHttpContext().User.FindFirst("sub")?.Value;
    }
    
    public static string? GetUserName(this ServerCallContext context) 
    {
        return context.GetHttpContext().User.FindFirst(x => x.Type == ClaimTypes.Name)?.Value;
    }
}
