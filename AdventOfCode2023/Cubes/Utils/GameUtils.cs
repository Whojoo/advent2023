namespace AdventOfCode2023.Cubes.Utils;

public static class GameUtils
{
    public static Dictionary<int, string> MapToGamesDict(List<string> games)
    {
        var dict = new Dictionary<int, string>();
        foreach (var game in games)
        {
            var splitIdAndContent = game.Split(": ");
            var gameId = int.Parse(splitIdAndContent[0].Split(' ')[1]);
            dict[gameId] = splitIdAndContent[1];
        }

        return dict;
    }
}