using AdventOfCode2023.Cubes.Models;
using AdventOfCode2023.Cubes.Utils;
using AdventOfCode2023.Extensions;

namespace AdventOfCode2023.Cubes.SimpleGame;

public class SimpleGameCalculationService : ICubesGameCalculationService
{
    private const int RedContent = 12;
    private const int GreenContent = 13;
    private const int BlueContent = 14;
    
    public string AssignmentName => "SimpleGame";

    public CubeGameResult CalculatePossibleGames(string input)
    {
        var games = input.SplitByLineBreaks();
        var gamesDict = GameUtils.MapToGamesDict(games);

        var possibleGames = GetPossibleGames(gamesDict);

        return new CubeGameResult(
            AssignmentName,
            possibleGames,
            possibleGames.Sum());
    }

    private static List<int> GetPossibleGames(Dictionary<int, string> gamesDict)
    {
        var results = new List<int>();
        foreach (var (gameId, game) in gamesDict)
        {
            if (IsGamePossible(game))
            {
                results.Add(gameId);
            }
        }

        return results;
    }

    private static bool IsGamePossible(string game)
    {
        var hands = game.Split("; ");
        return hands.SelectMany(hand => hand.Split(", ")).All(IsColorPossible);
    }

    private static bool IsColorPossible(string color)
    {
        var colorLimit = GetColorLimit(color);
        var numberAndColor = color.Split(' ');
        return int.Parse(numberAndColor[0]) <= colorLimit;
    }

    private static int GetColorLimit(string color)
    {
        if (color.EndsWith("red"))
        {
            return RedContent;
        }

        if (color.EndsWith("green"))
        {
            return GreenContent;
        }

        if (color.EndsWith("blue"))
        {
            return BlueContent;
        }

        throw new ArgumentException("Color unknown", color);
    }
}