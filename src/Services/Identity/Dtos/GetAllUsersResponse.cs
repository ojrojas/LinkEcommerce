namespace LinkEcommerce.Services.Identity.Dtos;

public record GetAllUsersResponse : BaseResponse
{
    public GetAllUsersResponse(Guid correlationId) : base(correlationId)
    {

    }

    public IEnumerable<UserViewModel> Users { get; set; }
}