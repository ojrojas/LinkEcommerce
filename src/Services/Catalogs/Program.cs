var builder = WebApplication.CreateBuilder(args);

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "catalog");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

var catalogs = app.NewVersionedApi();


app.MapDefaultEndpoints();

app.UseHttpsRedirection();

catalogs.MapCatalogEndpointsV1();
app.UseDefaultOpenApi();


app.Run();