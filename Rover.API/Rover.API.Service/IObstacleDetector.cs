namespace Rover.API.Service
{
    public interface IObstacleDetector
    {
        bool CanMove(int x, int y);
    }
}
