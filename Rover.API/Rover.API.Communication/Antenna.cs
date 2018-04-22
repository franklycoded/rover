using System;
using System.Linq;
using Rover.API.Service;

namespace Rover.API.Communication
{
    public class Antenna : IAntenna
    {
        protected readonly INavigationConfig _navConfig;
        protected readonly IRoverEngine _roverEngine;

        public Antenna(INavigationConfig navConfig, IRoverEngine roverEngine)
        {
            _navConfig = navConfig ?? throw new ArgumentNullException(nameof(navConfig));
            _roverEngine = roverEngine ?? throw new ArgumentNullException(nameof(roverEngine));
        }

        public MoveResult Move(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions)) throw new Exception("The instructions cannot be empty!");

            // Validate instruction set
            if(instructions.Any(c => c != 'F' && c != 'B' && c != 'L' && c != 'R'))
            {
                throw new Exception("There's an invalid instruction in set " + instructions);
            }

            MoveResult moveResult = null;

            foreach (var move in instructions)
            {
                switch (move)
                {
                    case 'F':
                        moveResult = _roverEngine.MoveForward();
                        break;
                    case 'B':
                        moveResult = _roverEngine.MoveBack();
                        break;
                    case 'L':
                        moveResult = _roverEngine.TurnLeft();
                        break;
                    case 'R':
                        moveResult = _roverEngine.TurnRight();
                        break;
                    default:
                        break;
                }

                if (moveResult.IsObstacleDetected) break;
            }

            return moveResult;
        }
    }
}
