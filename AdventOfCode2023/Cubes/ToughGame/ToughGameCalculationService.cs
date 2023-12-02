using AdventOfCode2023.Cubes.Models;
using AdventOfCode2023.Cubes.Utils;
using AdventOfCode2023.Extensions;

namespace AdventOfCode2023.Cubes.ToughGame;

public class ToughGameCalculationService : ICubesGameCalculationService
{
    private const int RedLength = 3;
    private const int BlueLength = 4;
    private const int GreenLength = 5;
    
    public string AssignmentName => "ToughGame";

    public CubeGameResult CalculatePossibleGames(string input)
    {
        var games = input.SplitByLineBreaks();
        var gamesDict = GameUtils.MapToGamesDict(games);

        var possibleGames = GetGamePowers(gamesDict);

        return new CubeGameResult(
            AssignmentName,
            possibleGames,
            possibleGames.Sum());
    }

    private static List<int> GetGamePowers(Dictionary<int, string> gamesDict)
        => gamesDict
            .Values
            .Select(CalculateGamePower)
            .ToList();

    private static int CalculateGamePower(string game)
    {
        var dict = new Dictionary<int, int>
        {
            {RedLength, 0},
            {BlueLength, 0},
            {GreenLength, 0},
        };
        
        var colors = game.Split("; ").SelectMany(hand => hand.Split(", "));
        foreach (var color in colors)
        {
            var numberAndColor = color.Split(' ');
            var colorLength = numberAndColor[1].Length;
            dict[colorLength] = Math.Max(dict[colorLength], int.Parse(numberAndColor[0]));
        }

        return dict[RedLength] * dict[BlueLength] * dict[GreenLength];
    }
}