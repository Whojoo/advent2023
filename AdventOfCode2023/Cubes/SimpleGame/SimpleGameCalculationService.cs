using AdventOfCode2023.Cubes.Models;

namespace AdventOfCode2023.Cubes.SimpleGame;

public class SimpleGameCalculationService : ICubesGameCalculationService
{
    private const int RedContent = 12;
    private const int GreenContent = 13;
    private const int BlueContent = 14;
    
    public string AssignmentName => "SimpleGame";

    public CubeGameResult CalculatePossibleGames(string input)
    {
        return new CubeGameResult("foo", new List<int>(), 0);
    }
}