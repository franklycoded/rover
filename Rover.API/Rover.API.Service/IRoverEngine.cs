namespace Rover.API.Service
{
    public interface IRoverEngine
    {
        MoveResult MoveForward();
        MoveResult MoveBack();
        Position GetPosition();
        MoveResult TurnLeft();
        MoveResult TurnRight();
    }
}
