namespace Rover.API.Service
{
    public interface IRoverEngine
    {
        Position MoveForward();
        Position MoveBack();
        Position GetPosition();
        Position TurnLeft();
        Position TurnRight();
    }
}
