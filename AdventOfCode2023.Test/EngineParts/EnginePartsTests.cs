using AdventOfCode2023.EngineParts;
using AdventOfCode2023.EngineParts.Simple;

namespace AdventOfCode2023.Test.EngineParts;

public class EnginePartsTests
{
    private readonly IEnginePartsService _simpleEnginePartsService = new SimpleEnginePartsService();

    [Fact]
    public void Assignment1()
    {
        const string testInput = "467..114..\n" +
                                 "...*......\n" +
                                 "..35..633.\n" +
                                 "......#...\n" +
                                 "617*......\n" +
                                 ".....+.58.\n" +
                                 "..592.....\n" +
                                 "......755.\n" +
                                 "...$.*....\n" +
                                 ".664.598..";

        var result = _simpleEnginePartsService.Calculate(testInput);

        result.EngineParts.Should().ContainInOrder(467, 35, 633, 617, 592, 755, 664, 598);
        result.Total.Should().Be(4361);
    } 
}