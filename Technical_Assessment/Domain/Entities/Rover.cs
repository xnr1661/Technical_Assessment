namespace Technical_Assessment.Domain.Entities;

using Technical_Assessment.Domain.Enums;
using Technical_Assessment.Domain.ValueObjects;

/*
I use this as an Entity because, in real use case,
information about various types of rovers would be stored in some data source along with 
credentials for connection. I am using methods that expose data, but there are different approaches, 
and sometimes it is recommended to exclude methods from domain objects. 
I included them here for simplicity and clarity.
*/
public class Rover
{
    private Direction _direction;
    private Position _position;

    public Rover(
        int positionX,
        int positionY,
        Direction startDirection)
    {
        _position = new Position(positionX, positionY);
        _direction = startDirection;
    }

    public void SetPosition(int newX, int newY)
        => _position.ChangePosition(newX, newY);

    public void SetDirection(Direction newDirection)
        => _direction = newDirection;

    public Position GetPosition() => _position;

    public Direction GetDirection() => _direction;

    public override string ToString()
        => $"Current rover position is X: {_position.X}, Y: {_position.Y} with direction {_direction.ToString()}";
}
