using AdventOfCode2023.RequestBinders;
using AdventOfCode2023.Trebuchet.Models;

namespace AdventOfCode2023.Trebuchet.Calibration;

public class CalibrationEndpoint : Endpoint<string, CalibrationResponse>
{
    private readonly ILogger<CalibrationEndpoint> _logger;
    private readonly ICalibrationService _calibrationService;

    public CalibrationEndpoint(ILogger<CalibrationEndpoint> logger, ICalibrationService calibrationService)
    {
        _logger = logger;
        _calibrationService = calibrationService;
    }

    public override void Configure()
    {
        Post("/api/trebuchet/calibration");
        AllowAnonymous();
        Options(x => x.Accepts<string>("text/plain"));
        RequestBinder(new PlainTextRequestBinder());
    }

    public override Task HandleAsync(string req, CancellationToken ct)
    {
        var result = _calibrationService.Calibrate(req);
        var response = result.ToResponse();
        _logger.LogInformation("Request: {Request}\nResult: {Result}\nResponse: {Response}", req, result, response);
        return SendAsync(response, cancellation: ct);
    }
}