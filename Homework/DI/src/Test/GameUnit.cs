public class GameUnit
{
    public (int X, int Y) Position;

    internal bool Move(Direction direction)
    {
        if (direction == Direction.Up) this.Position = (this.Position.X, this.Position.Y - 1);
        
        // ...

        return true;
    }
}

internal enum Direction { Left, Right, Up, Down }