namespace CountrySearch.Models;

/// <summary>Represents the result of a country search.</summary>
public sealed record CountrySearchResponse(
    string Query,
    int Count,
    IReadOnlyList<CountryResponse> Countries);
