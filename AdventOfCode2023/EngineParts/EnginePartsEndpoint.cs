using AdventOfCode2023.EngineParts.Models;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.EngineParts;

public class EnginePartsEndpoint : PlainTextEndpoint<List<EnginePartsResponse>>
{
    private readonly ILogger<EnginePartsEndpoint> _logger;
    private readonly IEnumerable<IEnginePartsService> _enginePartsServices;

    public EnginePartsEndpoint(ILogger<EnginePartsEndpoint> logger,
        IEnumerable<IEnginePartsService> enginePartsServices)
    {
        _logger = logger;
        _enginePartsServices = enginePartsServices;
    }

    protected override string Path => "/api/engine-parts";

    protected override List<EnginePartsResponse> ExecuteEndpoint(string input)
    {
        _logger.LogInformation("Received input {Input}", input);

        var responses = new List<EnginePartsResponse>();

        foreach (var service in _enginePartsServices)
        {
            var result = service.Calculate(input);
            var response = result.ToResponse();
            
            _logger.LogInformation(
                "Assignment: {Assignment}\nResult: {Result}\nResponse: {Response}", 
                service.AssignmentName, 
                result, 
                response);
            
            responses.Add(response);
        }

        return responses;
    }
}