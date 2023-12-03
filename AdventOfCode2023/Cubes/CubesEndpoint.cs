using AdventOfCode2023.Cubes.Models;
using AdventOfCode2023.Cubes.SimpleGame;
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.Cubes;

public class CubesEndpoint : PlainTextEndpoint<List<CubeGameResponse>>
{
    private readonly IEnumerable<ICubesGameCalculationService> _cubesGameCalculationServices;
    private readonly ILogger<CubesEndpoint> _logger;

    public CubesEndpoint(ILogger<CubesEndpoint> logger,
        IEnumerable<ICubesGameCalculationService> cubesGameCalculationServices)
    {
        _logger = logger;
        _cubesGameCalculationServices = cubesGameCalculationServices;
    }

    protected override string Path => "/api/cubes";

    protected override List<CubeGameResponse> ExecuteEndpoint(string input)
    {
        _logger.LogInformation("Received input: {Input}", input);
        
        var responses = new List<CubeGameResponse>();

        foreach (var service in _cubesGameCalculationServices)
        {
            var result = service.CalculatePossibleGames(input);
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