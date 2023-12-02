using AdventOfCode2023.Cubes.SimpleGame;
using AdventOfCode2023.Cubes.ToughGame;

namespace AdventOfCode2023.Cubes;

public static class CubesBootstrapper
{
    public static IServiceCollection AddCubes(this IServiceCollection services)
    {
        services.AddScoped<ICubesGameCalculationService, SimpleGameCalculationService>();
        services.AddScoped<ICubesGameCalculationService, ToughGameCalculationService>();

        return services;
    }
}