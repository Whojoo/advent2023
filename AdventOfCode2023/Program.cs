using AdventOfCode2023.Trebuchet.Calibration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICalibrationService, CalibrationService>();

var app = builder.Build();

app.UseFastEndpoints();

app.UseHttpsRedirection();

app.Run();