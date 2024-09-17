namespace Technical_Assessment.Application.Strategies;

using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

public class RightRotationStrategy : IRotationStrategy
{
    public bool IsApplicable(Movement movement)
        => movement == Movement.TurnRight;

    public void Rotate(Rover rover)
    {
        var currentDirection = rover.GetDirection();

        var directions = (Direction[])Enum.GetValues(currentDirection.GetType());
        int currentIndex = Array.IndexOf(directions, currentDirection);

        // Loop back to the start if it's the last element
        rover.SetDirection(directions[(currentIndex + 1) % directions.Length]);
    }
}
