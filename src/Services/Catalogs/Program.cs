var builder = WebApplication.CreateBuilder(args);

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "catalog");

var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDIOpenIddictApplication(configuration);
builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

#if DEBUG
var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

var context = service.GetRequiredService<CatalogDbContext>();
ArgumentNullException.ThrowIfNull(context);
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
#endif

var catalogs = app.NewVersionedApi();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


catalogs.MapCatalogEndpointsV1().RequireAuthorization();
app.UseDefaultOpenApi();


app.Run();