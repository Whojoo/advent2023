using AdventOfCode2023.EngineParts.Models;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.EngineParts;

public interface IEnginePartsService : IAssignmentService
{
    EnginePartsResults Calculate(string input);
}