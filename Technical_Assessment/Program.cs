using Technical_Assessment.Application.Services.Abstractions;
using Technical_Assessment.Application.Services;
using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Application.Strategies;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
            .AddScoped<IRoverService, RoverService>()
            .AddScoped<IMovementStrategy, ForwardMovementStrategy>()
            .AddScoped<IMovementStrategy, BackwardMovementStrategy>()
            .AddScoped<IRotationStrategy, LeftRotationStrategy>()
            .AddScoped<IRotationStrategy, RightRotationStrategy>()
            .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var roverService = scope.ServiceProvider.GetRequiredService<IRoverService>();

    var rover = new Rover(0, 0, Direction.North);

    roverService.ExecuteCommands(rover, "RBFXFFFLFFOOOFRGGGBR1");

    Console.WriteLine(rover.ToString());
}