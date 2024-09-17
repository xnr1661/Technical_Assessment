namespace Technical_Assessment.Application.Strategies.Abstractions;

using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

/*
 * The reason for separation movement and rotation is to clearly differentiate between different aspects of movement.
 * Which is highly recommended for a complex, technically advanced rover in a real world use case in my opinion.
 * */
public interface IMovementStrategy
{
    bool IsApplicable(Movement movement);

    void Move(Rover rover);
}
