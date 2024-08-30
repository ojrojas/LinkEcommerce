var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddRazorPages(config =>
{
    config.Conventions.AuthorizePage("/Account/Diagnostic");
    config.Conventions.AuthorizePage("/Account/Grants");
});

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

#if DEBUG
// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

var initializer = service.GetRequiredService<SeedIdentity>();
var context = service.GetRequiredService<IdentityAppDbContext>();
// var _managerApplication = service.GetRequiredService<IOpenIddictApplicationManager>();
// var _managerScopes = service.GetRequiredService<IOpenIddictScopeManager>();
await initializer.SeedAsync();
await initializer.CreateConfigurationOpenIddict();
#endif

var identity = app.NewVersionedApi();

app.MapDefaultEndpoints();

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


app.MapAuthorizeEndpointsV1();

identity.MapEndpointUserApplicationV1().RequireAuthorization();

app.MapRazorPages();
app.UseDefaultOpenApi();

app.Run();
