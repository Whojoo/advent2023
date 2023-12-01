namespace AdventOfCode2023.Trebuchet.Calibration;

public record CalibrationResult(List<int> CalibrationValues, int Total);

public static class CalibrationResultExtensions
{
    public static CalibrationResponse ToResponse(this CalibrationResult result)
        => new(result.CalibrationValues, result.Total);
}