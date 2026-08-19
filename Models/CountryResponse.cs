namespace CountrySearch.Models;

/// <summary>Represents a country returned by the API.</summary>
public sealed record CountryResponse(
    string Name,
    string Code,
    string Continent);
