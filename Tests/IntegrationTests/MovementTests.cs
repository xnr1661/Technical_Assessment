namespace Tests.IntegrationTests;

using Microsoft.Extensions.DependencyInjection;
using Technical_Assessment.Application.Services.Abstractions;
using Technical_Assessment.Application.Services;
using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Application.Strategies;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;
using FluentAssertions;

public class MovementTests
{
    [Theory]
    [InlineData("LLFFRBB", -2, 2, Direction.West, "Current rover position is X: -2, Y: 2 with direction West")]
    [InlineData("llffrbb", -2, 2, Direction.West, "Current rover position is X: -2, Y: 2 with direction West")]
    [InlineData("RFBBBLRFB", 0, -2, Direction.East, "Current rover position is X: 0, Y: -2 with direction East")]
    [InlineData("BFFLLBRRLBF", 2, 0, Direction.West, "Current rover position is X: 2, Y: 0 with direction West")]
    [InlineData("RBFXFFFLFFOOOFRGGGBR", 3, 2, Direction.South, "Current rover position is X: 3, Y: 2 with direction South")]
    [InlineData("QWETYUIOPASDGHJKZXCVNM", 0, 0, Direction.North, "Current rover position is X: 0, Y: 0 with direction North")]
    public void RoverMovement_OnApplicationActions_ShouldReturnProperRoverValues(
        string commands,
        int expectedXPosition,
        int expectedYPosition,
        Direction expectedDirection,
        string expectedRoverDescription)
    {
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

            roverService.ExecuteCommands(rover, commands);

            var roverPosition = rover.GetPosition();
            roverPosition.X.Should().Be(expectedXPosition);
            roverPosition.Y.Should().Be(expectedYPosition);

            var roverDirection = rover.GetDirection();
            roverDirection.Should().Be(expectedDirection);

            var description = rover.ToString();
            description.Should().Be(expectedRoverDescription);
        }
    }
}
