namespace Tests.UnitTests;

using Technical_Assessment.Application.Strategies;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

public class MovementStrategyTests
{
    private readonly ForwardMovementStrategy _forwardMovementStrategy;
    private readonly BackwardMovementStrategy _backwardMovementStrategy;

    public MovementStrategyTests()
    {
        _backwardMovementStrategy = new BackwardMovementStrategy();
        _forwardMovementStrategy = new ForwardMovementStrategy();
    }

    [Fact]
    public void ForwardMovementStrategy_OnIsApplicableCorrect_ShouldReturnTrue()
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _forwardMovementStrategy.IsApplicable(Movement.Forward);

        Assert.True(result);
    }

    [Fact]
    public void BackwardMovementStrategy_OnIsApplicableCorrect_ShouldReturnTrue()
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _backwardMovementStrategy.IsApplicable(Movement.Backward);

        Assert.True(result);
    }

    [Theory]
    [InlineData(Movement.Backward)]
    [InlineData(Movement.TurnLeft)]
    [InlineData(Movement.TurnRight)]
    public void ForwardMovementStrategy_OnIsApplicableNotCorrect_SchouldReturnFalse(Movement movement)
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _forwardMovementStrategy.IsApplicable(movement);

        Assert.False(result);
    }

    [Theory]
    [InlineData(Movement.TurnRight)]
    [InlineData(Movement.Forward)]
    [InlineData(Movement.TurnLeft)]
    public void BackwardMovementStrategy_OnIsApplicableNotCorrect_SchouldReturnFalse(Movement movement)
    {
        var rover = new Rover(0, 0, Direction.North);

        var result = _backwardMovementStrategy.IsApplicable(movement);

        Assert.False(result);
    }

    [Theory]
    [InlineData(0, 0, 1, 0, Direction.North)]
    [InlineData(0, 0, 0, 1, Direction.East)]
    public void ForwardMovementStrategy_OnExecute_ShouldReturnProperPosition(int beforeX, int beforeY, int afterX, int afterY, Direction direction)
    {
        var rover = new Rover(beforeX, beforeY, direction);

        _forwardMovementStrategy.Move(rover);

        var currentPosition = rover.GetPosition();
        Assert.Equal(currentPosition.X, afterX);
        Assert.Equal(currentPosition.Y, afterY);
    }

    [Theory]
    [InlineData(0, 0, -1, 0, Direction.North)]
    [InlineData(0, 0, 0, -1, Direction.East)]
    public void BackwardMovementStrategy_OnExecute_ShouldReturnProperDirection(int beforeX, int beforeY, int afterX, int afterY, Direction direction)
    {
        var rover = new Rover(beforeX, beforeY, direction);

        _backwardMovementStrategy.Move(rover);

        var currentPosition = rover.GetPosition();
        Assert.Equal(currentPosition.X, afterX);
        Assert.Equal(currentPosition.Y, afterY);
    }
}
