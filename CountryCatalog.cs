using CountrySearch.Models;

namespace CountrySearch;

public static class CountryCatalog
{
    // The demo keeps its data in memory so the example stays focused on telemetry.
    private static readonly CountryResponse[] All =
    [
        new("Brazil", "BR", "South America"),
        new("Portugal", "PT", "Europe"),
        new("Malta", "MT", "Europe"),
        new("France", "FR", "Europe"),
        new("Italy", "IT", "Europe"),
        new("Greece", "GR", "Europe"),
        new("Norway", "NO", "Europe"),
        new("Ireland", "IE", "Europe"),
        new("Iceland", "IS", "Europe"),
        new("Poland", "PL", "Europe"),
        new("Finland", "FI", "Europe"),
        new("Thailand", "TH", "Asia"),
        new("Switzerland", "CH", "Europe"),
        new("New Zealand", "NZ", "Oceania"),
        new("Netherlands", "NL", "Europe"),
        new("Japan", "JP", "Asia"),
        new("Chile", "CL", "South America"),
        new("Kenya", "KE", "Africa"),
        new("Nepal", "NP", "Asia"),
        new("Peru", "PE", "South America")
    ];

    public static CountryResponse[] Search(string query) =>
        [.. All.Where(country =>
            country.Name.Contains(query, StringComparison.OrdinalIgnoreCase))];
}
