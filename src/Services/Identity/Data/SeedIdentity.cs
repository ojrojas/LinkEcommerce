namespace LinkEcommerce.Services.Identity.Data;

public class SeedIdentity(
    ILoggerApplicationService<SeedIdentity> logger,
    IdentityAppDbContext context,
    UserManager<UserApplication> userManager,
    RoleManager<UserType> roleManager,
    IOpenIddictApplicationManager applicationManager,
    IOpenIddictScopeManager scopeManager,
    IConfiguration configuration)
{
    Guid USER_APPLICATION_ID = Guid.NewGuid();
    Guid TYPE_IDENTIFICATION_ID = Guid.NewGuid();
    Guid TYPE_USER_ID = Guid.NewGuid();
    Guid COMPANY_ID = Guid.NewGuid();
    Guid CARD_ID = Guid.NewGuid();

    private UserApplication CreateUserApplicationRequest()
    {

        return new UserApplication()
        {
            Id = USER_APPLICATION_ID,
            Name = "Pepe",
            LastName = "Perez",
            IdentificationNumber = "12345679",
            BirthDate = DateTime.UtcNow,
            Address = "CL 1 # 1",
            Contact = "123451234",
            IdentificationType = new()
            {
                Id = TYPE_IDENTIFICATION_ID,
                CreatedBy = USER_APPLICATION_ID,
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "CC"
            },
            IdentificationTypeId = TYPE_IDENTIFICATION_ID,
            Company = new Company
            {
                Id = COMPANY_ID,
                Name = "TEST_ADMIN",
                CreatedBy = USER_APPLICATION_ID,
                CreatedDate = DateTimeOffset.UtcNow,
                State = true
            },
            Card = new Card
            {
                Id = CARD_ID,
                Number = "XXXXXXXXXXXX1080",
                CardType = CardType.Credit,
                ExpirationDate = DateTime.UtcNow.AddMonths(6)
            },
            CardId = CARD_ID,
            UserName = "pepe@example.com",
        };
    }

    private UserType CreateRole()
    {
        return new UserType
        {
            Id = TYPE_USER_ID,
            Name = "Admin",
            NormalizedName = "Admin"
        };
    }

    public async ValueTask SeedAsync()
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        var userApplication = CreateUserApplicationRequest();
        var resultRole = await roleManager.CreateAsync(CreateRole());
        ArgumentNullException.ThrowIfNull(userApplication);
        var exists = await userManager.FindByNameAsync(userApplication.UserName);
        if (exists == null && resultRole.Succeeded)
        {
            userApplication.Email = userApplication.UserName;
            var result = await userManager.CreateAsync(userApplication, "Abc123456#");

            if (result.Succeeded)
            {
                logger.LogInformation("User identity created successful from seed idendity");

                if (resultRole.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Admin");
                    await userManager.AddToRoleAsync(userApplication, role.Name);
                    logger.LogInformation($"Add user to role: {role.Name}");
                }
            }
            else
                logger.LogError("Failed to create identity user");
        }
        else
            logger.LogError("Failed to create identity user");
    }

    public async ValueTask CreateConfigurationOpenIddict()
    {
        if (await applicationManager.FindByClientIdAsync("identity_swagger") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ApplicationType = ApplicationTypes.Native,
                ClientId = "identity_swagger",
                ClientType = ClientTypes.Public,
                DisplayName = "Identity Client Swagger",
                RedirectUris = { new Uri($"{configuration["IdentityApiClient"]}/swagger/oauth2-redirect.html") },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.CodeToken,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "identity_api",
                    },
                PostLogoutRedirectUris = { new Uri($"{configuration["IdentityApiClient"]}/swagger/") },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await scopeManager.FindByNameAsync("basket_api") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "basket_api",
                Resources =
                {
                    "resource_server_basket"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("catalog_api") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "catalog_api",
                Resources =
                {
                    "resource_server_catalog"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("order_api") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "order_api",
                Resources =
                {
                    "resource_server_order"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("identity_api") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "identity_api",
                Resources =
                {
                    "resource_server_identity"
                }
            });
        }
    }
}