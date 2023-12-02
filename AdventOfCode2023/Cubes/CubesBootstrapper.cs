using AdventOfCode2023.Cubes.SimpleGame;

namespace AdventOfCode2023.Cubes;

public static class CubesBootstrapper
{
    public static IServiceCollection AddCubes(this IServiceCollection services)
    {
        services.AddScoped<ICubesGameCalculationService, SimpleGameCalculationService>();

        return services;
    }
}