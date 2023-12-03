using AdventOfCode2023.RequestBinders;
using AdventOfCode2023.Trebuchet.Models;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.Trebuchet.Calibration;

public class CalibrationEndpoint : PlainTextEndpoint<CalibrationResponse>
{
    private readonly ILogger<CalibrationEndpoint> _logger;
    private readonly ICalibrationService _calibrationService;

    public CalibrationEndpoint(ILogger<CalibrationEndpoint> logger, ICalibrationService calibrationService)
    {
        _logger = logger;
        _calibrationService = calibrationService;
    }

    protected override string Path => "/api/trebuchet/calibration";

    protected override CalibrationResponse ExecuteEndpoint(string req)
    {
        var result = _calibrationService.Calibrate(req);
        var response = result.ToResponse();
        _logger.LogInformation("Request: {Request}\nResult: {Result}\nResponse: {Response}", req, result, response);
        return response;
    }
}