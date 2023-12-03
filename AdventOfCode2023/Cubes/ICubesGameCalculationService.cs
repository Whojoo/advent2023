using AdventOfCode2023.Cubes.Models;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.Cubes;

public interface ICubesGameCalculationService : IAssignmentService
{
    CubeGameResult CalculatePossibleGames(string input);
}