var builder = WebApplication.CreateBuilder(args);

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "catalog");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hola Mundo");

// app.MapCatalogEndpointsV1();
// app.UseDefaultOpenApi();


app.Run();