using AdventOfCode2023.Trebuchet.AdvancedCalibration;
using AdventOfCode2023.Trebuchet.Calibration;

namespace AdventOfCode2023.Trebuchet;

public static class TrebuchetBootstrapping
{
    public static IServiceCollection AddTrebuchet(this IServiceCollection services)
        => services
            .AddScoped<ICalibrationService, CalibrationService>()
            .AddScoped<IAdvancedCalibrationService, AdvancedCalibrationService>();
}