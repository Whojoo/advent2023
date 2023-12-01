using AdventOfCode2023.Trebuchet.Models;

namespace AdventOfCode2023.Trebuchet.Calibration;

public interface ICalibrationService
{
    public CalibrationResult Calibrate(string input);
}