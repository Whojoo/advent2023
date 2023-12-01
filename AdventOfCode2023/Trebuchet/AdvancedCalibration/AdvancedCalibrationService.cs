using AdventOfCode2023.Extensions;
using AdventOfCode2023.Trebuchet.Models;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Trebuchet.AdvancedCalibration;

public partial class AdvancedCalibrationService : IAdvancedCalibrationService
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

    private static int RetrieveCalibrationValue(string calibrationLine)
    {
        var firstNumber = RetrieveNumber(calibrationLine, FirstNumberRegex());
        var lastNumber = RetrieveNumber(calibrationLine, LastNumberRegex());
        return firstNumber * 10 + lastNumber;
    }

    private static int RetrieveNumber(string input, Regex regex)
    {
        var retrievedNumber = regex.Match(input).Groups["number"].Value;

        if (int.TryParse(retrievedNumber, out var intValue))
        {
            return intValue;
        }

        return retrievedNumber switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => throw new ArgumentOutOfRangeException("retrievedNumber", retrievedNumber)
        };
    }

    [GeneratedRegex(@"(?<number>\d|one|two|three|four|five|six|seven|eight|nine)")]
    private static partial Regex FirstNumberRegex();

    [GeneratedRegex(@".*(?<number>\d|one|two|three|four|five|six|seven|eight|nine)\w*$")]
    private static partial Regex LastNumberRegex();
}