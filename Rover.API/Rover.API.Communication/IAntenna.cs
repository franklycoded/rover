using Rover.API.Service;

namespace Rover.API.Communication
{
    public interface IAntenna
    {
        MoveResult Move(string instructions);
    }
}
