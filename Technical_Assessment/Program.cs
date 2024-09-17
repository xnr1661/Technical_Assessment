using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;

RoverService rover = new RoverService(0, 0, Direction.North);
rover.Move("LMLMLMLMM");
rover.PrintPosition();

public class RoverService
{
    Rover rover;

    public RoverService(int x, int y, Direction direction)
    {
        rover = new Rover(x, y, direction);
    }

    public void Move(string commands)
    {
        foreach (char command in commands)
        {
            if (command == 'L')
            {
                TurnLeft();
            }
            else if (command == 'R')
            {
                TurnRight();
            }
            else if (command == 'M')
            {
                MoveForward();
            }
        }
    }

    private void TurnLeft()
    {
        if (rover.GetDirection() == Direction.North) rover.SetDirection(Direction.West);
        else if (rover.GetDirection() == Direction.West) rover.SetDirection(Direction.South);
        else if (rover.GetDirection() == Direction.South) rover.SetDirection(Direction.East);
        else if (rover.GetDirection() == Direction.East) rover.SetDirection(Direction.North);
    }

    private void TurnRight()
    {
        if (rover.GetDirection() == Direction.North) rover.SetDirection(Direction.East);
        else if (rover.GetDirection() == Direction.West) rover.SetDirection(Direction.North);
        else if (rover.GetDirection() == Direction.South) rover.SetDirection(Direction.West);
        else if (rover.GetDirection() == Direction.East) rover.SetDirection(Direction.South);
    }

    private void MoveForward()
    {
        var currentPosition = rover.GetPosition();

        if (rover.GetDirection() == Direction.North) rover.SetPosition(currentPosition.X + 1, currentPosition.Y);
        else if (rover.GetDirection() == Direction.West) rover.SetPosition(currentPosition.X, currentPosition.Y - 1);
        else if (rover.GetDirection() == Direction.South) rover.SetPosition(currentPosition.X - 1, currentPosition.Y);
        else if (rover.GetDirection() == Direction.East) rover.SetPosition(currentPosition.X, currentPosition.Y + 1);
    }

    public void PrintPosition()
    {
        Console.WriteLine(rover.ToString());
    }
}
