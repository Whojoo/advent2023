namespace AdventOfCode2023.Trebuchet.Calibration;

public class CalibrationService : ICalibrationService
{
    public CalibrationResult Calibrate(string input) => new(new List<int>(), 0);
}