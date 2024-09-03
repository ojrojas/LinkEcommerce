var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "basket", configuration);

builder.AddBasicServiceDefaults();
builder.AddApplicationService();


builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<BaseService>();


app.Run();

