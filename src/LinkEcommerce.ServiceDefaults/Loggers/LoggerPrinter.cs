namespace LinkEcommerce.ServiceDefaults.Loggers;

public static class LoggerPrinter
{
  public static Serilog.ILogger CreateSerilogLogger(string key, string value) => new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty(key, value)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
}
