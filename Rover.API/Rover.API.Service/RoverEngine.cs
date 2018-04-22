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
            switch (_direction)
            {
                case EDirection.N:
                    _y--;
                    break;
                case EDirection.E:
                    _x--;
                    break;
                case EDirection.S:
                    _y++;
                    break;
                case EDirection.W:
                    _x++;
                    break;
            }

            return GetPosition();
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

        public Position TurnLeft()
        {
            var mod = ((int)_direction - 1) % 4;

            _direction = (EDirection)(mod < 0 ? mod + 4 : mod);

            return GetPosition();
        }

        public Position TurnRight()
        {
            _direction = (EDirection)(((int)_direction + 1) % 4);

            return GetPosition();
        }
    }
}
