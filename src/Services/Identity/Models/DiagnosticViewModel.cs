namespace LinkEcommerce.Services.Identity.Models;

public record DiagnosticViewModel
{
    public IList<Claim> Claims {get;set;} = new List<Claim>();
}