using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ServiceA.API;

using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog((context, loggerconfig) => loggerconfig.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddControllers();

        builder.Services.AddHttpClient();

        builder.Services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("ServiceA.API"))
            .WithTracing(tracing =>
            {
                tracing.AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation();
                tracing.AddOtlpExporter();
            });

        var app = builder.Build();


        app.UseHttpsRedirection();

        app.UseAuthorization();
        //app.UseSerilogRequestLogging();
        app.MapControllers();

        app.Run();
    }
}