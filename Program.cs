using CountrySearch;

var builder = WebApplication.CreateBuilder(args);

// Registers the MVC controller infrastructure used by the API.
builder.Services.AddControllers();

// Registers OpenTelemetry for logs, traces, and metrics.
builder.AddObservability();

var app = builder.Build();

// Maps routes declared with attributes in controller classes.
app.MapControllers();

app.Run();
