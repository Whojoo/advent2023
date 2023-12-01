using AdventOfCode2023.Trebuchet.Calibration;

namespace AdventOfCode2023.Test.Trebuchet;

public class CalibrationServiceTests
{
    private readonly ICalibrationService _calibrationService = new CalibrationService();

    [Fact]
    public void ShouldSucceedOnTestData()
    {
        const string testData = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        var result = _calibrationService.Calibrate(testData);

        result.CalibrationValues.Should().ContainInOrder(12, 38, 15, 77);
        result.Total.Should().Be(142);
    }
}