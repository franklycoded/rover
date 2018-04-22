using NUnit.Framework;

namespace Rover.API.Service.Tests
{
    [TestFixture]
    public class RoverEngineTests
    {
        private int _gridHeight;
        private int _gridWidth;

        [SetUp]
        public void Init()
        {
            _gridHeight = 100;
            _gridWidth = 100;
        }

        [Test]
        public void RoverEngine_Initialise()
        {
            var engine = new RoverEngine(5, 2, EDirection.S, _gridHeight, _gridWidth);

            var position = engine.GetPosition();

            Assert.AreEqual(5, position.X);
            Assert.AreEqual(2, position.Y);
            Assert.AreEqual(EDirection.S, position.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From00N_To01N()
        {
            var engine = new RoverEngine(0, 0, EDirection.N, _gridHeight, _gridWidth);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11E_To21E()
        {
            var engine = new RoverEngine(1, 1, EDirection.E, _gridHeight, _gridWidth);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(2, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11S_To10S()
        {
            var engine = new RoverEngine(1, 1, EDirection.S, _gridHeight, _gridWidth);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11W_To01W()
        {
            var engine = new RoverEngine(1, 1, EDirection.W, _gridHeight, _gridWidth);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11N_To10N()
        {
            var engine = new RoverEngine(1, 1, EDirection.N, _gridHeight, _gridWidth);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11E_To01E()
        {
            var engine = new RoverEngine(1, 1, EDirection.E, _gridHeight, _gridWidth);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11S_To12S()
        {
            var engine = new RoverEngine(1, 1, EDirection.S, _gridHeight, _gridWidth);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11W_To21W()
        {
            var engine = new RoverEngine(1, 1, EDirection.W, _gridHeight, _gridWidth);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(2, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnLeft_From11N_To11W()
        {
            var engine = new RoverEngine(1, 1, EDirection.N, _gridHeight, _gridWidth);

            var newPosition = engine.TurnLeft();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnLeft_From11E_To11N()
        {
            var engine = new RoverEngine(1, 1, EDirection.E, _gridHeight, _gridWidth);

            var newPosition = engine.TurnLeft();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnLeft_From11S_To11E()
        {
            var engine = new RoverEngine(1, 1, EDirection.S, _gridHeight, _gridWidth);

            var newPosition = engine.TurnLeft();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnLeft_From11W_To11S()
        {
            var engine = new RoverEngine(1, 1, EDirection.W, _gridHeight, _gridWidth);

            var newPosition = engine.TurnLeft();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnRight_From11N_To11E()
        {
            var engine = new RoverEngine(1, 1, EDirection.N, _gridHeight, _gridWidth);

            var newPosition = engine.TurnRight();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnRight_From11E_To11S()
        {
            var engine = new RoverEngine(1, 1, EDirection.E, _gridHeight, _gridWidth);

            var newPosition = engine.TurnRight();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnRight_From11S_To11W()
        {
            var engine = new RoverEngine(1, 1, EDirection.S, _gridHeight, _gridWidth);

            var newPosition = engine.TurnRight();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_TurnRight_From11W_To11N()
        {
            var engine = new RoverEngine(1, 1, EDirection.W, _gridHeight, _gridWidth);

            var newPosition = engine.TurnRight();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapUpward_MoveForward100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.N, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapUpward_MoveForward150_From15N_To1_55N()
        {
            var engine = new RoverEngine(1, 5, EDirection.N, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(55, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapEast_MoveForward100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.E, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapEast_MoveForward150_From15E_To51_5E()
        {
            var engine = new RoverEngine(1, 5, EDirection.E, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(51, newPosition.X);
            Assert.AreEqual(5, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapSouth_MoveForward100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.S, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapSouth_MoveForward150_From15S_To1_55S()
        {
            var engine = new RoverEngine(1, 5, EDirection.S, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(55, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapWest_MoveForward100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.W, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapWest_MoveForward150_From15W_To51_5W()
        {
            var engine = new RoverEngine(1, 5, EDirection.W, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveForward();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(51, newPosition.X);
            Assert.AreEqual(5, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapUpward_MoveBack100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.N, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapUpward_MoveBack150_From15N_To1_55N()
        {
            var engine = new RoverEngine(1, 5, EDirection.N, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(55, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapEast_MoveBack100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.E, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapEast_MoveBack150_From15E_To51_5E()
        {
            var engine = new RoverEngine(1, 5, EDirection.E, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(51, newPosition.X);
            Assert.AreEqual(5, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapSouth_MoveBack100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.S, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapSouth_MoveBack150_From15S_To1_55S()
        {
            var engine = new RoverEngine(1, 5, EDirection.S, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(55, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapWest_MoveBack100_ArriveAtSameSpot()
        {
            var engine = new RoverEngine(0, 0, EDirection.W, _gridHeight, _gridWidth);

            for (int i = 0; i < 100; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_WrapWest_MoveBack150_From15W_To51_5W()
        {
            var engine = new RoverEngine(1, 5, EDirection.W, _gridHeight, _gridWidth);

            for (int i = 0; i < 150; i++)
            {
                engine.MoveBack();
            }

            var newPosition = engine.GetPosition();

            Assert.AreEqual(51, newPosition.X);
            Assert.AreEqual(5, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }
    }
}
