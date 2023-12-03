using AdventOfCode2023.Trebuchet.Models;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.Trebuchet.AdvancedCalibration;

public class AdvancedCalibrationEndpoint : PlainTextEndpoint<CalibrationResponse>
{
    private readonly ILogger<AdvancedCalibrationEndpoint> _logger;
    private readonly IAdvancedCalibrationService _advancedCalibrationService;

    public AdvancedCalibrationEndpoint(ILogger<AdvancedCalibrationEndpoint> logger, 
        IAdvancedCalibrationService advancedCalibrationService)
    {
        _logger = logger;
        _advancedCalibrationService = advancedCalibrationService;
    }

    protected override string Path => "/api/trebuchet/advanced-calibration";

    protected override CalibrationResponse ExecuteEndpoint(string input)
    {
        var result = _advancedCalibrationService.Calibrate(input);
        var response = result.ToResponse();
        _logger.LogInformation("Request: {Request}\nResult: {Result}\nResponse: {Response}", input, result, response);
        return response;
    }
}