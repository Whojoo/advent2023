using AdventOfCode2023.RequestBinders;
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

    protected override void CustomConfigure()
    {
        Post("/api/trebuchet/advanced-calibration");
    }

    public override Task HandleAsync(string req, CancellationToken ct)
    {
        var result = _advancedCalibrationService.Calibrate(req);
        var response = result.ToResponse();
        _logger.LogInformation("Request: {Request}\nResult: {Result}\nResponse: {Response}", req, result, response);
        return SendAsync(response, cancellation: ct);
    }
}