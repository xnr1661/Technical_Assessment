namespace Technical_Assessment.Application.Strategies.Abstractions;

using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

public interface IRotationStrategy
{
    bool IsApplicable(Movement movement);

    void Rotate(Rover rover);
}
