namespace Technical_Assessment.Application.Strategies;

using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Common.Constants;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;
using Technical_Assessment.Domain.ValueObjects;

public class BackwardMovementStrategy : IMovementStrategy
{
    public bool IsApplicable(Movement movement)
        => movement == Movement.Backward;

    public void Move(Rover rover)
    {
        var currentPosition = rover.GetPosition();

        var newPosition = rover.GetDirection() switch
        {
            Direction.North => new Position(currentPosition.X - 1, currentPosition.Y),
            Direction.South => new Position(currentPosition.X + 1, currentPosition.Y),
            Direction.East => new Position(currentPosition.X, currentPosition.Y - 1),
            Direction.West => new Position(currentPosition.X, currentPosition.Y + 1),
            _ => throw new ArgumentException(ExceptionMessages.EnumException)
        };

        rover.SetPosition(newPosition.X, newPosition.Y);
    }
}
