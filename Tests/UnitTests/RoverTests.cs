namespace Tests.UnitTests;

using FluentAssertions;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

public class RoverTests
{
    [Fact]
    public void Rover_OnGetPosition_ShouldGetPositionProperly()
    {
        var rover = new Rover(10, 15, Direction.North);

        var currentPosition = rover.GetPosition();

        currentPosition.X.Should().Be(10);
        currentPosition.Y.Should().Be(15);
    }

    [Fact]
    public void Rover_OnGetDirection_ShouldGetDirectionProperly()
    {
        var rover = new Rover(10, 15, Direction.North);

        var currentDirection = rover.GetDirection();

        currentDirection.Should().Be(Direction.North);
    }

    [Fact]
    public void Rover_OnSetPosition_ShouldSetPositionProperly()
    {
        var rover = new Rover(10, 15, Direction.North);

        var currentPosition = rover.GetPosition();
        currentPosition.X.Should().Be(10);
        currentPosition.Y.Should().Be(15);

        rover.SetPosition(25, 30);

        currentPosition = rover.GetPosition();
        currentPosition.X.Should().Be(25);
        currentPosition.Y.Should().Be(30);
    }

    [Fact]
    public void Rover_OnSetDirection_ShouldSetDirectionnProperly()
    {
        var rover = new Rover(10, 15, Direction.North);

        var currentDirection = rover.GetDirection();
        currentDirection.Should().Be(Direction.North);

        rover.SetDirection(Direction.South);

        currentDirection = rover.GetDirection();
        currentDirection.Should().Be(Direction.South);
    }

    [Fact]
    public void Rover_OnToString_ShouldReturnProperDescription()
    {
        var rover = new Rover(10, 15, Direction.North);

        var toString = rover.ToString();

        toString.Should().Be("Current rover position is X: 10, Y: 15 with direction North");
    }
}
