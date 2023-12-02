using AdventOfCode2023.Cubes.Models;

namespace AdventOfCode2023.Cubes;

public interface ICubesGameCalculationService
{
    string AssignmentName { get; }
    
    CubeGameResult CalculatePossibleGames(string input);
}