using AdventOfCode2023.Trebuchet.Models;

namespace AdventOfCode2023.Trebuchet.AdvancedCalibration;

public interface IAdvancedCalibrationService
{
    public CalibrationResult Calibrate(string input);
}