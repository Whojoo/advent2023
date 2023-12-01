using AdventOfCode2023.Trebuchet.AdvancedCalibration;

namespace AdventOfCode2023.Test.Trebuchet;

public class AdvancedCalibrationServiceTests
{
    private readonly IAdvancedCalibrationService _advancedCalibrationService = new AdvancedCalibrationService();

    [Fact]
    public void ShouldSucceedOnTestData()
    {
        const string testData =
            "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        
        var result = _advancedCalibrationService.Calibrate(testData);

        result.CalibrationValues.Should().ContainInOrder(29, 83, 13, 24, 42, 14, 76);
        result.Total.Should().Be(281);
    }
}