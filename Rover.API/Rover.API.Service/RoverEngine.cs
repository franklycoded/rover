using System;

namespace Rover.API.Service
{
    public class RoverEngine : IRoverEngine
    {
        private int _x;
        private int _y;
        private EDirection _direction;
        private int _gridHeight;
        private int _gridWidth;

        public RoverEngine(int x, int y, EDirection direction, int gridHeight, int gridWidth)
        {
            _x = x;
            _y = y;
            _gridHeight = gridHeight;
            _gridWidth = gridWidth;
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
                    _y = CalcMod(_y - 1, _gridHeight);
                    break;
                case EDirection.E:
                    _x = CalcMod(_x - 1, _gridWidth);
                    break;
                case EDirection.S:
                    _y = CalcMod(_y + 1, _gridHeight);
                    break;
                case EDirection.W:
                    _x = CalcMod(_x + 1, _gridWidth);
                    break;
            }

            return GetPosition();
        }

        public Position MoveForward()
        {
            switch (_direction)
            {
                case EDirection.N:
                    _y = CalcMod(_y + 1, _gridHeight);
                    break;
                case EDirection.E:
                    _x = CalcMod(_x + 1, _gridWidth);
                    break;
                case EDirection.S:
                    _y = CalcMod(_y - 1, _gridHeight);
                    break;
                case EDirection.W:
                    _x = CalcMod(_x - 1, _gridWidth);
                    break;
            }

            return GetPosition();
        }

        public Position TurnLeft()
        {
            var rem = ((int)_direction - 1) % 4;

            _direction = (EDirection)CalcMod((int)_direction - 1, 4);

            return GetPosition();
        }

        public Position TurnRight()
        {
            _direction = (EDirection)(((int)_direction + 1) % 4);

            return GetPosition();
        }

        private int CalcMod(int num, int mod)
        {
            var rem = num % mod;

            return rem < 0 ? rem + mod : rem;
        }
    }
}
