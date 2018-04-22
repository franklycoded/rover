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
        private IObstacleDetector _obstacleDetector;

        public RoverEngine(int x, int y, EDirection direction, int gridHeight, int gridWidth, IObstacleDetector obstacleDetector)
        {
            _x = x;
            _y = y;
            _gridHeight = gridHeight;
            _gridWidth = gridWidth;
            _direction = direction;

            _obstacleDetector = obstacleDetector ?? throw new ArgumentNullException(nameof(obstacleDetector));
        }

        public Position GetPosition()
        {
            return new Position(_x, _y, _direction);
        }

        public MoveResult MoveBack()
        {
            int tempY = _y;
            int tempX = _x;

            switch (_direction)
            {
                case EDirection.N:
                    tempY = CalcMod(_y - 1, _gridHeight);
                    break;
                case EDirection.E:
                    tempX = CalcMod(_x - 1, _gridWidth);
                    break;
                case EDirection.S:
                    tempY = CalcMod(_y + 1, _gridHeight);
                    break;
                case EDirection.W:
                    tempX = CalcMod(_x + 1, _gridWidth);
                    break;
            }

            if (_obstacleDetector.CanMove(tempX, tempY))
            {
                _x = tempX;
                _y = tempY;

                return new MoveResult(GetPosition(), false);
            }

            return new MoveResult(GetPosition(), true);
        }

        public MoveResult MoveForward()
        {
            int tempY = _y;
            int tempX = _x;

            switch (_direction)
            {
                case EDirection.N:
                    tempY = CalcMod(_y + 1, _gridHeight);
                    break;
                case EDirection.E:
                    tempX = CalcMod(_x + 1, _gridWidth);
                    break;
                case EDirection.S:
                    tempY = CalcMod(_y - 1, _gridHeight);
                    break;
                case EDirection.W:
                    tempX = CalcMod(_x - 1, _gridWidth);
                    break;
            }

            if(_obstacleDetector.CanMove(tempX, tempY))
            {
                _x = tempX;
                _y = tempY;

                return new MoveResult(GetPosition(), false);
            }

            return new MoveResult(GetPosition(), true);
        }

        public MoveResult TurnLeft()
        {
            var rem = ((int)_direction - 1) % 4;

            _direction = (EDirection)CalcMod((int)_direction - 1, 4);

            return new MoveResult(GetPosition(), false);
        }

        public MoveResult TurnRight()
        {
            _direction = (EDirection)(((int)_direction + 1) % 4);

            return new MoveResult(GetPosition(), false);
        }

        // This helper function calculates mod with negative number support to implement wrapping in an elegant fashion
        private int CalcMod(int num, int mod)
        {
            var rem = num % mod;

            return rem < 0 ? rem + mod : rem;
        }
    }
}
