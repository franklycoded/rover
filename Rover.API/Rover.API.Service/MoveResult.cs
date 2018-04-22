namespace Rover.API.Service
{
    public class MoveResult
    {
        public Position Position { get; private set; }
        public bool IsObstacleDetected { get; set; }

        public MoveResult(Position position, bool isObstacleDetected)
        {
            Position = position;
            IsObstacleDetected = isObstacleDetected;
        }
    }
}
