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
                ApplicationType = ApplicationTypes.Web,
                ClientId = "identity_swagger",
                ClientType = ClientTypes.Public,
                DisplayName = "Identity Client Swagger",
                RedirectUris = { new Uri($"{configuration["IdentityApiClient"]}/swagger/oauth2-redirect.html") },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "identity_api",
                        // Permissions.Prefixes.Scope + "catalog_api"
                    },
                PostLogoutRedirectUris = { new Uri($"{configuration["IdentityApiClient"]}/connect/logout"), new Uri($"{configuration["IdentityApiClient"]}/swagger/") },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await applicationManager.FindByClientIdAsync("catalog_swagger") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ApplicationType = ApplicationTypes.Web,
                ClientId = "catalog_swagger",
                ClientType = ClientTypes.Public,
                DisplayName = "Catalog Client Swagger",
                RedirectUris = { new Uri($"{configuration["CatalogApiClient"]}/swagger/oauth2-redirect.html") },
                Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Implicit,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "catalog_scope"
                    },
                PostLogoutRedirectUris = { new Uri($"{configuration["IdentityApiClient"]}/connect/logout"), new Uri($"{configuration["CatalogApiClient"]}/swagger/") },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            });
        }

        if (await applicationManager.FindByClientIdAsync("catalog_api") is null)
        {
            await applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "catalog_api",
                ClientSecret = "a2344152-e928-49e7-bb3c-ee54acc96c8c",
                DisplayName = "Catalog Client Api",
                Permissions = {
                        Permissions.Endpoints.Introspection,
                    }
            });
        }

        if (await scopeManager.FindByNameAsync("catalog_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "catalog_scope",
                Resources =
                {
                    "catalog_api",
                    "identity_scope"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("basket_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "basket_scope",
                Resources =
                {
                    "resource_server_basket"
                }
            });
        }
        if (await scopeManager.FindByNameAsync("order_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "order_scope",
                Resources =
                {
                    "resource_server_order"
                }
            });
        }

        if (await scopeManager.FindByNameAsync("identity_scope") is null)
        {
            await scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "identity_scope",
                Resources =
                {
                    "resource_server_identity"
                }
            });
        }
    }
}