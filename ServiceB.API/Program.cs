using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

namespace ServiceB.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog((context, loggerconfig) => loggerconfig.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();


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