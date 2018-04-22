using Moq;
using NUnit.Framework;
using Rover.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.API.Communication.Tests
{
    [TestFixture]
    public class AntennaTests
    {
        private Mock<INavigationConfig> _mockNavigationConfig;
        private Mock<IRoverEngine> _mockRoverEngine;

        [SetUp]
        public void Init()
        {
            _mockNavigationConfig = new Mock<INavigationConfig>();
            _mockRoverEngine = new Mock<IRoverEngine>();
        }

        [Test]
        public void Antenna_Constructor_NoNavigationConfig_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var antenna = new Antenna(null, _mockRoverEngine.Object);
            });
        }

        [Test]
        public void Antenna_Constructor_NoRoverEngine_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var antenna = new Antenna(_mockNavigationConfig.Object, null);
            });
        }

        [Test]
        public void Antenna_Move_InstructionsNull_Exception()
        {
            Assert.Throws<Exception>(() =>
            {
                var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

                var result = antenna.Move(null);
            }, "The instructions cannot be empty!");
        }

        [Test]
        public void Antenna_Move_InstructionsEmpty_Exception()
        {
            Assert.Throws<Exception>(() =>
            {
                var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

                var result = antenna.Move(" ");
            }, "The instructions cannot be empty!");
        }

        [Test]
        public void Antenna_Move_InvalidInstructionInSet_Exception()
        {
            Assert.Throws<Exception>(() =>
            {
                var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);
                var result = antenna.Move("FBWL");

            }, "There's an invalid instruction in set FBWL!");
        }

        [Test]
        public void Antenna_Move_F_CallMoveForward()
        {
            _mockRoverEngine.Setup(m => m.MoveForward()).Returns(new MoveResult(new Position(1, 1, EDirection.N), false));

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            antenna.Move("F");

            _mockRoverEngine.Verify(m => m.MoveForward(), Times.Once);
        }

        [Test]
        public void Antenna_Move_B_CallMoveBack()
        {
            _mockRoverEngine.Setup(m => m.MoveBack()).Returns(new MoveResult(new Position(1, 1, EDirection.N), false));

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            antenna.Move("B");

            _mockRoverEngine.Verify(m => m.MoveBack(), Times.Once);
        }

        [Test]
        public void Antenna_Move_L_CallTurnLeft()
        {
            _mockRoverEngine.Setup(m => m.TurnLeft()).Returns(new MoveResult(new Position(1, 1, EDirection.W), false));

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            antenna.Move("L");

            _mockRoverEngine.Verify(m => m.TurnLeft(), Times.Once);
        }

        [Test]
        public void Antenna_Move_R_CallTurnRight()
        {
            _mockRoverEngine.Setup(m => m.TurnRight()).Returns(new MoveResult(new Position(1, 1, EDirection.E), false));

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            antenna.Move("R");

            _mockRoverEngine.Verify(m => m.TurnRight(), Times.Once);
        }

        [Test]
        public void Antenna_Move_VerifySequentialOrder()
        {
            var instructions = "BLFR";
            var callOrder = 0;

            var dummyResult = new MoveResult(new Position(2, 2, EDirection.S), false);
            var finalMoveResult = new MoveResult(new Position(1, 1, EDirection.N), false);

            _mockRoverEngine.Setup(m => m.MoveBack()).Callback(() => Assert.That(callOrder++ == 0)).Returns(dummyResult);
            _mockRoverEngine.Setup(m => m.TurnLeft()).Callback(() => Assert.That(callOrder++ == 1)).Returns(dummyResult);
            _mockRoverEngine.Setup(m => m.MoveForward()).Callback(() => Assert.That(callOrder++ == 2)).Returns(dummyResult);
            _mockRoverEngine.Setup(m => m.TurnRight()).Callback(() => Assert.That(callOrder++ == 3)).Returns(finalMoveResult);

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            var result = antenna.Move(instructions);

            Assert.IsNotNull(result);
            Assert.AreEqual(finalMoveResult, result);
        }

        [Test]
        public void Antenna_Move_VerifySequentialOrder_WithObstacle_StopAtObstacle()
        {
            var instructions = "BLFR";
            var callOrder = 0;

            var dummyResult = new MoveResult(new Position(2, 2, EDirection.S), false);
            var obstacleMoveResult = new MoveResult(new Position(5, 5, EDirection.S), true);
            var finalMoveResult = new MoveResult(new Position(1, 1, EDirection.N), false);

            _mockRoverEngine.Setup(m => m.MoveBack()).Callback(() => Assert.That(callOrder++ == 0)).Returns(dummyResult);
            _mockRoverEngine.Setup(m => m.TurnLeft()).Callback(() => Assert.That(callOrder++ == 1)).Returns(obstacleMoveResult);
            _mockRoverEngine.Setup(m => m.MoveForward()).Callback(() => Assert.That(callOrder++ == 2)).Returns(dummyResult);
            _mockRoverEngine.Setup(m => m.TurnRight()).Callback(() => Assert.That(callOrder++ == 3)).Returns(finalMoveResult);

            var antenna = new Antenna(_mockNavigationConfig.Object, _mockRoverEngine.Object);

            var result = antenna.Move(instructions);

            Assert.IsNotNull(result);
            Assert.AreEqual(obstacleMoveResult, result);
            Assert.IsTrue(result.IsObstacleDetected);
            Assert.AreEqual(2, callOrder);
        }
    }
}
