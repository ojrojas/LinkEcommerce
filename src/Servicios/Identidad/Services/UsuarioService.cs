using System.Security.Claims;
using LinkEcommerce.ServiceDefaults.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace LinkEcommerce.Servicios.Identidad.Services;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly ILoggerAplicacionService<UsuarioService> _logger;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly RoleManager<TipoUsuario> _roleManager;
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IOpenIddictAuthorizationManager _authorizationManager;
    private readonly IOpenIddictScopeManager _scopeManager;

    public UsuarioService(
        UserManager<Usuario> userManager,
        RoleManager<TipoUsuario> roleManager,
        ILoggerAplicacionService<UsuarioService> logger,
        SignInManager<Usuario> signInManager,
        IOpenIddictApplicationManager applicationManager,
        IOpenIddictAuthorizationManager authorizationManager,
        IOpenIddictScopeManager scopeManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(userManager));
        _applicationManager = applicationManager ?? throw new ArgumentNullException(nameof(userManager));
        _authorizationManager = authorizationManager ?? throw new ArgumentNullException(nameof(userManager));
        _scopeManager = scopeManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async ValueTask<CrearUsuarioResponse> CrearUsuarioAplicacionAsync(CrearUsuarioRequest request,
                                                                                CancellationToken cancellationToken)
    {
        CrearUsuarioResponse response = new(request.CorrelacionId);
        _logger.LogInformation(response, "Crear usuario de aplicacion request");
        var usuarioAplicacion = RemapeadoUsuarioAplicacion(request.Usuario);
        var identidadResult = await _userManager.CreateAsync(usuarioAplicacion, request.Seguridad.Contrasena);

        if (identidadResult.Succeeded)
        {
            response.UsuarioCreado = request.Usuario;
            _logger.LogInformation(response, "Usuario de aplicacion creado con exito");
        }
        else
            _logger.LogError(response, "Error al crear el usuario de aplicacion");

        return response;
    }

    public async ValueTask<ActualizarUsuarioResponse> ActualizarUsuarioAplicacionAsync(ActualizarUsuarioRequest request,
                                                                                CancellationToken cancellationToken)
    {
        ActualizarUsuarioResponse response = new(request.CorrelacionId);
        _logger.LogInformation(response, "Peticion de actualizacion de usuario request");
        var userAplicacion = RemapeadoUsuarioAplicacion(request.Usuario);
        var identidadResult = await _userManager.UpdateAsync(userAplicacion);

        if (identidadResult.Succeeded)
        {
            response.UsuarioActualizado = request.Usuario;
            _logger.LogInformation(response, "Usuario de aplicacion actualizado con exito");
        }
        else
            _logger.LogError(response, "Error al actualizar  usuario de aplicacion");

        return response;
    }

    public async ValueTask<EliminarUsuarioResponse> EliminarUsuarioAplicacionAsync(EliminarUsuarioRequest request, CancellationToken cancellationToken)
    {
        EliminarUsuarioResponse response = new(request.CorrelacionId);
        _logger.LogInformation(response, "Eliminar usuario de aplicacion request");
        var userAplicacion = await _userManager.FindByIdAsync(request.Id.ToString());
        ArgumentNullException.ThrowIfNull(userAplicacion);
        var identidadResult = await _userManager.DeleteAsync(userAplicacion);

        if (identidadResult.Succeeded)
            _logger.LogInformation(response, "Usuario eliminado con exito");
        else
        {
            response.EstaEliminado = false;
            _logger.LogError(response, "Error al eliminar usuario de aplicacion");
        }

        return response;
    }

    public async ValueTask<ObtenerUsuarioPorIdResponse> ObtenerUsuarioAplicacionAsync(ObtenerUsuarioPorIdRequest request, CancellationToken cancellationToken)
    {
        ObtenerUsuarioPorIdResponse response = new(request.CorrelacionId);
        _logger.LogInformation(response, "Obtener usuario de aplicacion por id requed");
        var userAplicacion = await _userManager.FindByIdAsync(request.Id.ToString());
        response.TipoUsuario = await _userManager.GetRolesAsync(userAplicacion);
        ArgumentNullException.ThrowIfNull(userAplicacion);
        response.UsuarioViewModel = RemapeadoUsuarioViewModel(userAplicacion);
        _logger.LogInformation(response, "Encontrar usuario de aplicacion por id exito");
        return response;
    }

    public async ValueTask<IResult> LoginAplicacionAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        LoginResponse response = new(request.CorrelacionId);
        _logger.LogInformation(response, "login user application request");
        var userApplication = await _userManager.FindByEmailAsync(request.NombreUsuario);
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

        var result = await _signInManager.PasswordSignInAsync(request.NombreUsuario, request.Contrasena, true, false);

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

        identity.SetDestinations(ObtenerDestinacionExtensions.ObtenerDestinaciones);
        if (result.Succeeded)
        {
            _logger.LogInformation("Login user application successful");
            return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        return Results.BadRequest("Failed to login request or not posible");
    }

    public async ValueTask<IResult> LoginAplicacionAsync(HttpContext context, CancellationToken cancellationToken)
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

        identity.SetDestinations(ObtenerDestinacionExtensions.ObtenerDestinaciones);
        if (result.Succeeded)
        {
            _logger.LogInformation("Login user application successful");
            return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        return Results.BadRequest("Failed to login request or not posible");
    }

    public async ValueTask<ObtenerTodosUsuariosResponse> ObtenerTodosUsuariosAsync(ObtenerTodosUsuariosRequest request, CancellationToken cancellationToken)
    {
        ObtenerTodosUsuariosResponse response = new(request.CorrelacionId);
        _logger.LogInformation("Get all user application request");
        response.Usuarios = _userManager.Users.Select(x => RemapeadoUsuarioViewModel(x));
        _logger.LogInformation("Get user all users application in role");
        return response;
    }

    private static Usuario RemapeadoUsuarioAplicacion(UsuarioViewModel register)
    {
        return new Usuario
        {
            Id = register.Id,
            Nombre = register.Nombre,
            SegundoNombre = register.SegundoNombre,
            Apellido = register.Apellido,
            SegundoApellido = register.SegundoApellido,
            TipoIdentificacion = register.TipoIdentificacion,
            TipoIdentificacionId = register.TipoIdentificacionId,
            Identificacion = register.Identificacion,
            FechaNacimiento = register.FechaNacimiento,
            Direccion = register.Direccion,
            Contacto = register.Contacto,
            TarjetaBancaria = register.TarjetaBancaria,
            TarjetaBancariaId = register.TarjetaBancariaId,
            Compania = register.Compania,
            CompaniaId = register.CompaniaId
        };
    }

    private static UsuarioViewModel RemapeadoUsuarioViewModel(Usuario userApplication)
    {
        return new UsuarioViewModel
        {
            Id = userApplication.Id,
            Nombre = userApplication.Nombre,
            SegundoNombre = userApplication.SegundoNombre,
            Apellido = userApplication.Apellido,
            SegundoApellido = userApplication.SegundoApellido,
            TipoIdentificacion = userApplication.TipoIdentificacion,
            TipoIdentificacionId = userApplication.TipoIdentificacionId,
            Identificacion = userApplication.Identificacion,
            FechaNacimiento = userApplication.FechaNacimiento,
            Direccion = userApplication.Direccion,
            Contacto = userApplication.Contacto,
            TarjetaBancaria = userApplication.TarjetaBancaria,
            TarjetaBancariaId = userApplication.TarjetaBancariaId,
            Compania = userApplication.Compania,
            CompaniaId = userApplication.CompaniaId
        };
    }
}