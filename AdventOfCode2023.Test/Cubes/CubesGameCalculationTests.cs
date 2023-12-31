using AdventOfCode2023.Cubes.SimpleGame;
using AdventOfCode2023.Cubes.ToughGame;

namespace AdventOfCode2023.Test.Cubes;

public class CubesGameCalculationTests
{
    private readonly SimpleGameCalculationService _simpleGameCalculationService = new();
    private readonly ToughGameCalculationService _toughGameCalculationService = new();

    [Fact]
    public void ShouldWorkWithTestInput()
    {
        const string testInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\n" +
                                 "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\n" +
                                 "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\n" +
                                 "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\n" +
                                 "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        var result = _simpleGameCalculationService.CalculatePossibleGames(testInput);

        result.PossibleIDs.Should().ContainInOrder(1, 2, 5);
        result.PossibleSum.Should().Be(8);
    }

    [Fact]
    public void ToughTest()
    {
        const string testInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\n" +
                                 "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\n" +
                                 "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\n" +
                                 "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\n" +
                                 "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        var result = _toughGameCalculationService.CalculatePossibleGames(testInput);

        result.PossibleIDs.Should().ContainInOrder(48, 12, 1560, 630, 36);
        result.PossibleSum.Should().Be(2286);
    }
}