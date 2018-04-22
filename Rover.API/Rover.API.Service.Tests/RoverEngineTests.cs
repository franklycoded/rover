using NUnit.Framework;

namespace Rover.API.Service.Tests
{
    [TestFixture]
    public class RoverEngineTests
    {
        [Test]
        public void RoverEngine_Initialise()
        {
            var engine = new RoverEngine(5, 2, EDirection.S);

            var position = engine.GetPosition();

            Assert.AreEqual(5, position.X);
            Assert.AreEqual(2, position.Y);
            Assert.AreEqual(EDirection.S, position.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From00N_To01N()
        {
            var engine = new RoverEngine(0, 0, EDirection.N);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11E_To21E()
        {
            var engine = new RoverEngine(1, 1, EDirection.E);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(2, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11S_To10S()
        {
            var engine = new RoverEngine(1, 1, EDirection.S);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveForward_From11W_To01W()
        {
            var engine = new RoverEngine(1, 1, EDirection.W);

            var newPosition = engine.MoveForward();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11N_To10N()
        {
            var engine = new RoverEngine(1, 1, EDirection.N);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(0, newPosition.Y);
            Assert.AreEqual(EDirection.N, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11E_To01E()
        {
            var engine = new RoverEngine(1, 1, EDirection.E);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.E, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11S_To12S()
        {
            var engine = new RoverEngine(1, 1, EDirection.S);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(EDirection.S, newPosition.Direction);
        }

        [Test]
        public void RoverEngine_MoveBack_From11W_To21W()
        {
            var engine = new RoverEngine(1, 1, EDirection.W);

            var newPosition = engine.MoveBack();

            Assert.AreEqual(2, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(EDirection.W, newPosition.Direction);
        }
    }
}
