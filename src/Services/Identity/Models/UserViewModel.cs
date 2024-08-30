namespace LinkEcommerce.Services.Identity.Models;
public record UserViewModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? SurName { get; set; }
    public required IdentificationType IdentificationType { get; set; }
    public Guid IdentificationTypeId { get; set; }
    public required string IdentificationNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Address { get; set; }
    public required string Contact { get; set; }
    public Card Card { get; set; }
    public Guid CardId { get; set; }
    public Company Company { get; set; }
    public Guid CompanyId { get; set; }
}

public record SecurityRegistryUser
{
    public required string Password { get; set; }
    public required string CorfirmedPassword { get; set; }
    public bool IsConFirmedPassword => Password.Equals(CorfirmedPassword);
}