# country-search

A small ASP.NET Core API used to show what OpenTelemetry records on its own, and what it cannot.

One route, `GET /api/countries/search?query=land`, searching a list of countries held in memory. No database, no external call. The application is deliberately dull so the telemetry is the interesting part.

It emits all three OpenTelemetry signals — traces, metrics and logs — and declares exactly one thing itself:

```csharp
Activity.Current?.SetTag("search.results.count", countries.Length);
```

Everything else arrives from `AddAspNetCoreInstrumentation()`.

## Running it

Start a local OpenTelemetry backend. The Aspire Dashboard works and needs nothing installed:

```bash
docker run --rm -p 18888:18888 -p 4317:18889 \
  mcr.microsoft.com/dotnet/aspire-dashboard:latest
```

It prints a login URL with a token. Then run the API against it:

```bash
OTEL_EXPORTER_OTLP_ENDPOINT=http://localhost:4317 dotnet run
```

```bash
curl "http://localhost:5077/api/countries/search?query=land"
```

Open the dashboard at <http://localhost:18888> and the request is there under Traces, Metrics and Structured logs.

## The write-up

This repository is the demo for [Getting started with OpenTelemetry in .NET: what it is and what you get for free](https://danieldias.dev/en/blog/opentelemetry-in-dotnet).

Requires .NET 10.
