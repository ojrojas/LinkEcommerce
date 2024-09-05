var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var endpointSeq =configuration["SeqEndpoint"];

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "catalog", configuration);

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
var seed = service.GetRequiredService<CatalogSeed>();

ArgumentNullException.ThrowIfNull(context);
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await seed.SeedAsync();

#endif

var catalogs = app.NewVersionedApi();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


catalogs.MapCatalogEndpointsV1();
app.UseDefaultOpenApi();


app.Run();