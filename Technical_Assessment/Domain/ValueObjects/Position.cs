namespace Technical_Assessment.Domain.ValueObjects;

public struct Position
{
    public int X { get; private set; }

    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void ChangePosition(int x, int y)
    {
        X = x;
        Y = y;
    }
}