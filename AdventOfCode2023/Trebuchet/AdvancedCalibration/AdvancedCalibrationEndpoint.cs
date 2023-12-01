using AdventOfCode2023.RequestBinders;
using AdventOfCode2023.Trebuchet.Models;

namespace AdventOfCode2023.Trebuchet.AdvancedCalibration;

public class AdvancedCalibrationEndpoint : Endpoint<string, CalibrationResponse>
{
    private readonly ILogger<AdvancedCalibrationEndpoint> _logger;
    private readonly IAdvancedCalibrationService _advancedCalibrationService;

    public AdvancedCalibrationEndpoint(ILogger<AdvancedCalibrationEndpoint> logger, 
        IAdvancedCalibrationService advancedCalibrationService)
    {
        _logger = logger;
        _advancedCalibrationService = advancedCalibrationService;
    }

    public override void Configure()
    {
        Post("/api/trebuchet/advanced-calibration");
        AllowAnonymous();
        Options(x => x.Accepts<string>("text/plain"));
        RequestBinder(new PlainTextRequestBinder());
    }

    public override Task HandleAsync(string req, CancellationToken ct)
    {
        var result = _advancedCalibrationService.Calibrate(req);
        var response = result.ToResponse();
        _logger.LogInformation("Request: {Request}\nResult: {Result}\nResponse: {Response}", req, result, response);
        return SendAsync(response, cancellation: ct);
    }
}