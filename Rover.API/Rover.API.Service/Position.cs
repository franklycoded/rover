namespace Rover.API.Service
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public EDirection Direction { get; private set; }

        public Position(int x, int y, EDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
