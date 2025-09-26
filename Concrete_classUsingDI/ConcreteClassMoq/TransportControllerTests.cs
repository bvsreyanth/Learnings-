using Concrete_classUsingDI.Models;
using Moq;

namespace ConcreteClassMoq
{
    public class TransportControllerTests
    {
        public Mock<Car> carMock;
        public Mock<Bicycle> bicycleMock;
        [SetUp]
        public void SetUp()
        {
            carMock = new Mock<Car>();
            bicycleMock = new Mock<Bicycle>();
        }
        [Test]
        public void Drive_ReturnsExpectedValue()
        {
            //Arrange
            carMock.Setup(c => c.Drive()).Returns("Mocked driving result");
            //Act
            var result = carMock.Object.Drive();

            //Assert
            Assert.AreEqual("Mocked driving result", result);

            carMock.Verify(c => c.Drive(), Times.Once);
        }

        [Test]
        public void Bicycle_ReturnsExpectedValue()
        {
            //Arrange
            bicycleMock.Setup(b => b.Ride()).Returns("Mocked Ride result");
            //Act
            var result = bicycleMock.Object.Ride();
            //Assert
            Assert.AreEqual("Mocked Ride result", result);
        }

        [Test]
        public void UseTransport_ShouldCallDriveAndRideMethods()
        {
            // Arrange

            bicycleMock.Setup(x => x.Ride()).Returns("Mocked Ride result");
            var result = bicycleMock.Object.Ride();
            //Assert
            Assert.AreEqual("Mocked Ride result", result);
        }

    }
}