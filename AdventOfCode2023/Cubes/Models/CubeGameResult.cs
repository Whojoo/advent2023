namespace AdventOfCode2023.Cubes.Models;

public record CubeGameResult(string Assignment, List<int> PossibleIDs, int PossibleSum);

public static class CubeGameResultExtensions
{
    public static CubeGameResponse ToResponse(this CubeGameResult result)
        => new(result.Assignment, result.PossibleSum);
}