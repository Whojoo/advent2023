using AdventOfCode2023.EngineParts.Models;
using AdventOfCode2023.Extensions;

namespace AdventOfCode2023.EngineParts.Simple;

public class SimpleEnginePartsService : IEnginePartsService
{
    public string AssignmentName => "SimpleEngineParts";

    public EnginePartsResults Calculate(string input)
    {
        var lines = input.SplitByLineBreaks();
        var height = lines.Count;
        var width = lines[0].Length;

        var validEngineParts = new List<int>();

        var isGroupingDigits = false;
        var currentDigit = string.Empty;
        var digitStartX = int.MaxValue;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var character = lines[y][x];
                var isDigit = char.IsDigit(character);

                if (isDigit)
                {
                    isGroupingDigits = true;
                    currentDigit += character;
                    digitStartX = Math.Min(x, digitStartX);
                }

                var loopTerminating = x == width - 1;

                var finishGrouping = (isDigit && loopTerminating) || (!isDigit && isGroupingDigits);

                if (!finishGrouping)
                {
                    continue;
                }

                var boxStartX = Math.Max(digitStartX - 1, 0);
                var boxEndX = x;
                var boxStartY = Math.Max(y - 1, 0);
                var boxEndY = Math.Min(y + 1, height - 1);

                if (IsValidDigit(lines, boxStartX, boxStartY, boxEndX, boxEndY))
                {
                    validEngineParts.Add(int.Parse(currentDigit));
                }

                isGroupingDigits = false;
                currentDigit = string.Empty;
                digitStartX = int.MaxValue;
            }
        }

        return new EnginePartsResults(
            AssignmentName,
            validEngineParts,
            validEngineParts.Sum());
    }

    private static bool IsValidDigit(List<string> world, int startX, int startY, int endX, int endY)
    {
        foreach (var area in GetSurroundingArea(world, startX, startY, endX, endY))
        {
            var isDigit = char.IsDigit(area);
            var isPeriod = area == '.';
            if (!isDigit && !isPeriod)
            {
                return true;
            }
        }

        return false;
    }

    private static IEnumerable<char> GetSurroundingArea(List<string> world, int startX, int startY, int endX, int endY)
    {
        for (var x = startX; x <= endX; x++)
        {
            yield return world[startY][x];
            yield return world[endY][x];
        }

        var y = startY + 1;

        yield return world[y][startX];
        yield return world[y][endX];
    }
}