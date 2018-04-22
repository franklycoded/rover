using System;

namespace Rover.API.Service
{
    public class RoverEngine : IRoverEngine
    {
        private int _x;
        private int _y;
        private EDirection _direction;

        public RoverEngine(int x, int y, EDirection direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public Position GetPosition()
        {
            return new Position(_x, _y, _direction);
        }

        public Position MoveBack()
        {
            throw new NotImplementedException();
        }

        public Position MoveForward()
        {
            switch (_direction)
            {
                case EDirection.N:
                    _y++;
                    break;
                case EDirection.E:
                    _x++;
                    break;
                case EDirection.S:
                    _y--;
                    break;
                case EDirection.W:
                    _x--;
                    break;
            }

            return GetPosition();
        }
    }
}
