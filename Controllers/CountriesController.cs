using System.Diagnostics;
using CountrySearch.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountrySearch.Controllers;

[ApiController]
[Route("api/countries")]
public sealed class CountriesController(ILogger<CountriesController> logger) : ControllerBase
{
    /// <summary>Searches countries by name.</summary>
    [HttpGet("search")]
    [ProducesResponseType<CountrySearchResponse>(StatusCodes.Status200OK)]
    public ActionResult<CountrySearchResponse> Search([FromQuery] string query)
    {
        CountryResponse[] countries = CountryCatalog.Search(query);

        // A normal ILogger call. OpenTelemetry stamps it with the current
        // TraceId, which is what links this log line back to its request.
        logger.LogInformation(
            "Searched for {Query} and found {Count} countries", query, countries.Length);

        // ASP.NET Core created the current span automatically.
        // This custom attribute adds information only the application knows.
        Activity.Current?.SetTag("search.results.count", countries.Length);

        var response = new CountrySearchResponse(
            Query: query,
            Count: countries.Length,
            Countries: countries);

        return Ok(response);
    }
}
