namespace LinkEcommerce.ServiceDefaults.Extensions;

public static class ObtenerDestinacionExtensions
{
    public static IEnumerable<string> ObtenerDestinaciones(Claim claim)
    {
        return claim.Type switch
        {
            Claims.Name or
            Claims.Subject
                => new[] { Destinations.AccessToken, Destinations.IdentityToken },

            _ => [Destinations.AccessToken],
        };
    }
}