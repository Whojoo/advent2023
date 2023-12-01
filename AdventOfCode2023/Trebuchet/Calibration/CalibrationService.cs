using AdventOfCode2023.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Trebuchet.Calibration;

public partial class CalibrationService : ICalibrationService
{
    public CalibrationResult Calibrate(string input)
    {
        var calibrationValues = input
            .SplitByLineBreaks()
            .Select(RetrieveCalibrationValue)
            .ToList();

        var total = calibrationValues.Sum();

        return new CalibrationResult(calibrationValues, total);
    }

    private int RetrieveCalibrationValue(string calibrationLine)
    {
        var firstNumber = int.Parse(FirstNumberRegex().Match(calibrationLine).Groups["firstNumber"].Value);
        var lastNumber = int.Parse(LastNumberRegex().Match(calibrationLine).Groups["lastNumber"].Value);
        return firstNumber * 10 + lastNumber;
    }

    [GeneratedRegex(@"(?<firstNumber>\d)")]
    private static partial Regex FirstNumberRegex();

    [GeneratedRegex(@".*(?<lastNumber>\d)\w*$")]
    private static partial Regex LastNumberRegex();
}