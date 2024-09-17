namespace Technical_Assessment.Application.Services;

using Technical_Assessment.Application.Services.Abstractions;
using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

/*
 * In my opinion, using CQRS and splitting into command (movement and rotation) and Queries (fetching position) 
 * would be a much better solution. However, for simplicity, I used a service.
 * */
public class RoverService : IRoverService
{
    private readonly IEnumerable<IMovementStrategy> _movementStrategies;
    private readonly IEnumerable<IRotationStrategy> _rotationStrategies;

    public RoverService(
        IEnumerable<IMovementStrategy> movementStrategies,
        IEnumerable<IRotationStrategy> rotationStrategies)
    {
        _movementStrategies = movementStrategies;
        _rotationStrategies = rotationStrategies;
    }

    public void ExecuteCommands(Rover rover, string commands)
    {
        foreach (var command in commands.ToCharArray())
        {
            switch (command.ToString().ToUpper())
            {
                case "F":
                    ExecuteMovement(rover, Movement.Forward);
                    break;
                case "B":
                    ExecuteMovement(rover, Movement.Backward);
                    break;
                case "L":
                    ExecuteRotation(rover, Movement.TurnLeft);
                    break;
                case "R":
                    ExecuteRotation(rover, Movement.TurnRight);
                    break;
                default:
                    continue;
            }
        }
    }

    private void ExecuteMovement(Rover rover, Movement movement)
    {
        var strategy = GetMovementStrategy(movement);

        if (strategy == null)
            return;

        strategy.Move(rover);
    }

    private void ExecuteRotation(Rover rover, Movement movement)
    {
        var strategy = GetRotationStrategy(movement);

        if (strategy == null)
            return;

        strategy.Rotate(rover);
    }

    private IMovementStrategy? GetMovementStrategy(Movement movement)
        => _movementStrategies.SingleOrDefault(ms => ms.IsApplicable(movement));

    private IRotationStrategy? GetRotationStrategy(Movement movement)
        => _rotationStrategies.SingleOrDefault(ms => ms.IsApplicable(movement));
}
