namespace Rover.API.Service
{
    public class ObstacleDetector : IObstacleDetector
    {
        public bool CanMove(int x, int y)
        {
            return (x + y) % 2 == 0;
        }
    }
}
