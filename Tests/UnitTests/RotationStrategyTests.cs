namespace Tests.UnitTests;

using FluentAssertions;
using Technical_Assessment.Application.Strategies;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

public class RotationStrategyTests
{
    private readonly LeftRotationStrategy _leftRotationStrategy;
    private readonly RightRotationStrategy _rightRotationStrategy;

    public RotationStrategyTests()
    {
        _leftRotationStrategy = new LeftRotationStrategy();
        _rightRotationStrategy = new RightRotationStrategy();
    }

    [Fact]
    public void LeftRotationStrategy_OnIsApplicableCorrect_ShouldReturnTrue()
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _leftRotationStrategy.IsApplicable(Movement.TurnLeft);

        Assert.True(result);
    }

    [Fact]
    public void RightRotationStrategy_OnIsApplicableCorrect_ShouldReturnTrue()
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _rightRotationStrategy.IsApplicable(Movement.TurnRight);

        Assert.True(result);
    }

    [Theory]
    [InlineData(Movement.Backward)]
    [InlineData(Movement.Forward)]
    [InlineData(Movement.TurnRight)]
    public void LeftRotationStrategy_OnIsApplicableNotCorrect_SchouldReturnFalse(Movement movement)
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _leftRotationStrategy.IsApplicable(movement);

        Assert.False(result);
    }

    [Theory]
    [InlineData(Movement.Backward)]
    [InlineData(Movement.Forward)]
    [InlineData(Movement.TurnLeft)]
    public void RightRotationStrategy_OnIsApplicableNotCorrect_SchouldReturnFalse(Movement movement)
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _rightRotationStrategy.IsApplicable(movement);

        Assert.False(result);
    }

    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.East, Direction.North)]
    public void LeftRotationStrategy_OnExecute_ShouldReturnProperDirection(Direction before, Direction after)
    {
        var rover = new Rover(0, 0, before);

        _leftRotationStrategy.Rotate(rover);

        rover.GetDirection().Should().Be(after);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.West, Direction.North)]
    public void RightRotationStrategy_OnExecute_ShouldReturnProperDirection(Direction before, Direction after)
    {
        var rover = new Rover(0, 0, before);

        _rightRotationStrategy.Rotate(rover);

        rover.GetDirection().Should().Be(after);
    }
}
