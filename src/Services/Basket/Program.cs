var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "basket", configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGrpcService<BaseService>();


app.Run();

