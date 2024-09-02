namespace LinkEcommerce.ServiceDefaults.Loggers;

public static class LoggerPrinter
{
  public static Serilog.ILogger CreateSerilogLogger(string key, string value, IConfiguration configuration) => new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty(key, value)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq(configuration["SeqEndpoint"])
            .CreateLogger();
}
