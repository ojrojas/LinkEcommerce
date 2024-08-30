namespace LinkEcommerce.Services.Identity.Interfaces;

public interface IUserApplicationServices
{
    ValueTask<CreateUserResponse> CreateUserAsync(CreateUserRequest request,
                                             CancellationToken cancellationToken);
    ValueTask<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request,
                                                                   CancellationToken cancellationToken);

    ValueTask<DeleteUserResponse> DeleteUserAsync(
        DeleteUserRequest request, CancellationToken cancellationToken);
    ValueTask<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request,
                                                                     CancellationToken cancellationToken);

    ValueTask<IResult> LoginAsync(HttpContext context, CancellationToken cancellationToken);
    ValueTask<IResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken);

    ValueTask<GetAllUsersResponse> GetAllUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken);
}