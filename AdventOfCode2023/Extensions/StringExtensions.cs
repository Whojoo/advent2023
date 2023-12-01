namespace AdventOfCode2023.Extensions;

public static class StringExtensions
{
    public static List<string> SplitByLineBreaks(this string target)
        => target.Split('\n').ToList();
}