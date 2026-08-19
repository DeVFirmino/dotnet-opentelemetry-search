using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CountrySearch;

public static class Observability
{
    // This name identifies the application in every exported telemetry signal.
    private const string ServiceName = "country-search";

    public static void AddObservability(this WebApplicationBuilder builder) =>
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(ServiceName))
            .WithTracing(tracing => tracing
                // Automatically creates a span for every HTTP request.
                .AddAspNetCoreInstrumentation())
            .WithMetrics(metrics => metrics
                // Automatically records ASP.NET Core request metrics.
                .AddAspNetCoreInstrumentation())
            // Sends ILogger output through OpenTelemetry, stamped with the current TraceId.
            .WithLogging()
            // Exports all three signals over OTLP. The endpoint comes from
            // the OTEL_EXPORTER_OTLP_ENDPOINT environment variable.
            .UseOtlpExporter();
}
