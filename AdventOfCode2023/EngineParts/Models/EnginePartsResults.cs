namespace AdventOfCode2023.EngineParts.Models;

public record EnginePartsResults(string Assignment, List<int> EngineParts, int Total);

public static class EnginePartsResultsExtensions
{
    public static EnginePartsResponse ToResponse(this EnginePartsResults results)
        => new(results.Assignment, results.Total);
}