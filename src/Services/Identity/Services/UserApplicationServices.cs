namespace LinkEcommerce.Services.Identity.Services;

public class UserApplicationServices : IUserApplicationServices
{
    private readonly UserManager<UserApplication> _userManager;
    private readonly ILoggerApplicationService<UserApplicationServices> _logger;
    private readonly SignInManager<UserApplication> _signInManager;
    // private readonly RoleManager<UserType> _roleManager;
    // private readonly IOpenIddictApplicationManager _applicationManager;
    // private readonly IOpenIddictAuthorizationManager _authorizationManager;
    // private readonly IOpenIddictScopeManager _scopeManager;

    public UserApplicationServices(
        UserManager<UserApplication> userManager,
        ILoggerApplicationService<UserApplicationServices> logger,
        SignInManager<UserApplication> signInManager
        // RoleManager<UserType> roleManager,
        // IOpenIddictApplicationManager applicationManager,
        // IOpenIddictAuthorizationManager authorizationManager,
        // IOpenIddictScopeManager scopeManager
        )
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(userManager));
        // _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        // _applicationManager = applicationManager ?? throw new ArgumentNullException(nameof(userManager));
        // _authorizationManager = authorizationManager ?? throw new ArgumentNullException(nameof(userManager));
        // _scopeManager = scopeManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async ValueTask<CreateUserResponse> CreateUserAsync(CreateUserRequest request,
                                                                                CancellationToken cancellationToken)
    {
        CreateUserResponse response = new(request.CorrelationId);
        _logger.LogInformation(response, "Create userapplication request");
        var userApplication = RemapedUserApplication(request.User);
        var identityResult = await _userManager.CreateAsync(userApplication, request.Security.Password);

        if (identityResult.Succeeded)
        {
            response.UserCreated = request.User;
            _logger.LogInformation(response, "User application created successful");
        }
        else
            _logger.LogError(response, "Error to created user application");

        if(cancellationToken.IsCancellationRequested && !identityResult.Succeeded)
        {
            _logger.LogWarning("User application request is cancelled");
            await _userManager.DeleteAsync(RemapedUserApplication(response.UserCreated));
            response.UserCreated = null;
        }

        return response;
    }

    public async ValueTask<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request,
                                                                                CancellationToken cancellationToken)
    {
        UpdateUserResponse response = new(request.CorrelationId);
        _logger.LogInformation(response, "Update user application request");
        var userApplication = RemapedUserApplication(request.User);
        var currentUserApplication = await _userManager.FindByIdAsync(request.User.Id.ToString());
        var identityResult = await _userManager.UpdateAsync(userApplication);

        if (identityResult.Succeeded)
        {
            response.UserUpdated = request.User;
            _logger.LogInformation(response, "User application created successful");
        }
        else
            _logger.LogError(response, "Error to created user application");

         if(cancellationToken.IsCancellationRequested && !identityResult.Succeeded)
        {
            _logger.LogWarning("User application request is cancelled");
            await _userManager.UpdateAsync(currentUserApplication);
            response.UserUpdated = null;
        }

        return response;
    }

    public async ValueTask<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        DeleteUserResponse response = new(request.CorrelationId);
        _logger.LogInformation(response, "Delete user application request");
        var userApplication = await _userManager.FindByIdAsync(request.Id.ToString());
        ArgumentNullException.ThrowIfNull(userApplication);
        var identityResult = await _userManager.DeleteAsync(userApplication);

        if (identityResult.Succeeded)
            _logger.LogInformation(response, "User application delete successful");
        else
        {
            response.UserDeleted = false;
            _logger.LogError(response, "Error to delete user application");
        }

        if(cancellationToken.IsCancellationRequested && !identityResult.Succeeded)
        {
            _logger.LogWarning("User application request is cancelled");
            await _userManager.UpdateAsync(userApplication);
            response.UserDeleted = false;
        }

        return response;
    }

    public async ValueTask<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request)
    {
        GetUserByIdResponse response = new(request.CorrelationId);
        _logger.LogInformation(response, "Get user application id request");
        var userApplication = await _userManager.FindByIdAsync(request.Id.ToString());
        response.UserTypes = await _userManager.GetRolesAsync(userApplication);
        ArgumentNullException.ThrowIfNull(userApplication);
        response.User = RemapedRegisterUserApplication(userApplication);
        _logger.LogInformation(response, "Find application user response successful");
        return response;
    }

    public async ValueTask<IResult> LoginAsync(LoginRequest request)
    {
        LoginResponse response = new(request.CorrelationId);
        _logger.LogInformation(response, "login user application request");
        var userApplication = await _userManager.FindByEmailAsync(request.UserName);
        if (userApplication == null)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                "The username/password couple is invalid."
            });

            return Results.Forbid(properties, [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme]);
        }

        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);
        
        if (!result.Succeeded)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                    "The username/password couple is invalid."
            });

            return Results.Forbid(properties, [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme]);
        }

        _logger.LogInformation($"Credentials user validate successful: {result.Succeeded}");
        var identity = new ClaimsIdentity(
        authenticationType: TokenValidationParameters.DefaultAuthenticationType,
        nameType: Claims.Name,
        roleType: Claims.Role);

        // Add the claims that will be persisted in the tokens.
        identity.SetClaim(Claims.Subject, await _userManager.GetUserIdAsync(userApplication))
                .SetClaim(Claims.Email, await _userManager.GetEmailAsync(userApplication))
                .SetClaim(Claims.Name, await _userManager.GetUserNameAsync(userApplication))
                .SetClaim(Claims.PreferredUsername, await _userManager.GetUserNameAsync(userApplication))
                .SetClaims(Claims.Role, [.. (await _userManager.GetRolesAsync(userApplication))]);

        // Set the list of scopes granted to the client application.
        identity.SetScopes(new[]
        {
                Scopes.OpenId,
                Scopes.Email,
                Scopes.Profile,
                Scopes.Roles
        }
        // .Intersect(request)
        );

        identity.SetDestinations(GetDestination.GetDestinations);
        if (result.Succeeded)
        {
            _logger.LogInformation("Login user application successful");
            return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        return Results.BadRequest("Failed to login request or not posible");
    }

    public async ValueTask<IResult> LoginAsync(HttpContext context)
    {
        var request = context.GetOpenIddictServerRequest() ??
            throw new InvalidOperationException("Error request operation not found a valid request auth openid");

        var parameters = request.GetParameters();

        _logger.LogInformation($"Login user application request {parameters}");
        var userApplication = await _userManager.FindByEmailAsync(request.Username);
        _logger.LogInformation($"user: {userApplication}");
        ArgumentNullException.ThrowIfNull(userApplication);

        if (userApplication == null)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                    "The username/password couple is invalid."
            });

            return Results.Forbid(properties, [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme]);
        }

        var result = await _signInManager.PasswordSignInAsync(userApplication, request.Password, true, false);

        if (!result.Succeeded)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                    "The username/password couple is invalid."
            });

            return Results.Forbid(properties, [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme]);
        }

        _logger.LogInformation($"Credentials user validate successful: {result.Succeeded}");
        var identity = new ClaimsIdentity(
        authenticationType: TokenValidationParameters.DefaultAuthenticationType,
        nameType: Claims.Name,
        roleType: Claims.Role);

        // Add the claims that will be persisted in the tokens.
        identity.SetClaim(Claims.Subject, await _userManager.GetUserIdAsync(userApplication))
                .SetClaim(Claims.Email, await _userManager.GetEmailAsync(userApplication))
                .SetClaim(Claims.Name, await _userManager.GetUserNameAsync(userApplication))
                .SetClaim(Claims.PreferredUsername, await _userManager.GetUserNameAsync(userApplication))
                .SetClaims(Claims.Role, [.. (await _userManager.GetRolesAsync(userApplication))]);

        // Set the list of scopes granted to the client application.
        identity.SetScopes(new[]
        {
                Scopes.OpenId,
                Scopes.Email,
                Scopes.Profile,
                Scopes.Roles
        }
        .Intersect(request.GetScopes()));

        identity.SetDestinations(GetDestination.GetDestinations);
        if (result.Succeeded)
        {
            _logger.LogInformation("Login user application successful");
            return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        return Results.BadRequest("Failed to login request or not posible");
    }

    public async ValueTask<GetAllUsersResponse> GetAllUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        GetAllUsersResponse response = new(request.CorrelationId);
        _logger.LogInformation("Get all user application request");
        var usersApplications = await _userManager.GetUsersInRoleAsync("Admin");
        response.Users = usersApplications.Select(x=> RemapedRegisterUserApplication(x));
        _logger.LogInformation("Get user all users application in role");
        return response;
    }

    private static UserApplication RemapedUserApplication(UserViewModel userViewModel)
    {
        ArgumentNullException.ThrowIfNull(userViewModel);
        return new UserApplication
        {
            Id = userViewModel.Id,
            Name = userViewModel.Name,
            MiddleName = userViewModel.MiddleName,
            LastName = userViewModel.LastName,
            SurName = userViewModel.SurName,
            IdentificationType = userViewModel.IdentificationType,
            IdentificationTypeId = userViewModel.IdentificationTypeId,
            IdentificationNumber = userViewModel.IdentificationNumber,
            BirthDate = userViewModel.BirthDate,
            Address = userViewModel.Address,
            Contact = userViewModel.Contact,
            Card = userViewModel.Card,
            CardId = userViewModel.CardId,
            Company = userViewModel.Company,
            CompanyId = userViewModel.CompanyId,
        };
    }

    private static UserViewModel RemapedRegisterUserApplication(UserApplication userApplication)
    {
        ArgumentNullException.ThrowIfNull(userApplication);
        return new UserViewModel
        {
            Id = userApplication.Id,
            Name = userApplication.Name,
            MiddleName = userApplication.MiddleName,
            LastName = userApplication.LastName,
            SurName = userApplication.SurName,
            IdentificationType = userApplication.IdentificationType,
            IdentificationTypeId = userApplication.IdentificationTypeId,
            IdentificationNumber = userApplication.IdentificationNumber,
            BirthDate = userApplication.BirthDate,
            Address = userApplication.Address,
            Contact = userApplication.Contact,
            Card = userApplication.Card,
            CardId = userApplication.CardId,
            Company = userApplication.Company,
            CompanyId = userApplication.CompanyId
        };
    } 
}