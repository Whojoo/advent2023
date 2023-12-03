using AdventOfCode2023.EngineParts.Simple;

namespace AdventOfCode2023.EngineParts;

public static class EnginePartsBootstrapper
{
    public static IServiceCollection AddEngineParts(this IServiceCollection services)
        => services.AddScoped<IEnginePartsService, SimpleEnginePartsService>();
}