namespace LinkEcommerce.Services.Identity.Dtos;

public record LoginRequest : BaseRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string ReturnUrl { get; set; }
}