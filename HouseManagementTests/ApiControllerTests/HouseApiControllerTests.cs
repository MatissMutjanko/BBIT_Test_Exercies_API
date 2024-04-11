using AutoMapper;
using BBIT_Test_Exercises_House;
using BBIT_Test_Exercises_House.Controllers;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace YourProject.Tests
{
    [TestFixture]
    public class HouseControllerTests
    {
        private HouseApiController _houseController;
        private Mock<IHouseService> _mockHouseService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>().Object;
            _mockHouseService = new Mock<IHouseService>();
            _houseController = new HouseApiController(_mapper, _mockHouseService.Object);
        }

        [Test]
        public void AddHouse_WhenHouseIsUnique_ReturnsCreatedResult()
        {
            // Arrange
            var house = new House { Id = 1, Number = 123, City = "City", Country = "Country", Street = "Street", PostalIndex = "12345" };
            _mockHouseService.Setup(service => service.GetById(house.Id)).Returns((House)null);

            // Act
            var result = _houseController.AddHouse(house);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void AddHouse_WhenHouseIsNotUnique_ReturnsConflictResult()
        {
            // Arrange
            var existingHouse = new House { Id = 1, Number = 123, City = "City", Country = "Country", Street = "Street", PostalIndex = "12345" };
            _mockHouseService.Setup(service => service.GetById(existingHouse.Id)).Returns(existingHouse);

            // Act
            var result = _houseController.AddHouse(existingHouse);

            // Assert
            Assert.IsInstanceOf<ConflictResult>(result);
        }

        [Test]
        public void GetHouse_WhenHouseExists_ReturnsOkResult()
        {
            // Arrange
            var houseId = 1;
            var existingHouse = new House { Id = houseId, Number = 123, City = "City", Country = "Country", Street = "Street", PostalIndex = "12345" };
            _mockHouseService.Setup(service => service.GetById(houseId)).Returns(existingHouse);

            // Act
            var result = _houseController.GetHouse(houseId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetHouse_WhenHouseDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var houseId = 1;
            _mockHouseService.Setup(service => service.GetById(houseId)).Returns((House)null);

            // Act
            var result = _houseController.GetHouse(houseId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void DeleteHouse_WhenHouseExists_ReturnsOkResult()
        {
            // Arrange
            var houseId = 1;
            var existingHouse = new House { Id = houseId, Number = 123, City = "City", Country = "Country", Street = "Street", PostalIndex = "12345" };
            _mockHouseService.Setup(service => service.GetById(houseId)).Returns(existingHouse);

            // Act
            var result = _houseController.DeleteHouse(houseId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void DeleteHouse_WhenHouseDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var houseId = 1;
            _mockHouseService.Setup(service => service.GetById(houseId)).Returns((House)null);

            // Act
            var result = _houseController.DeleteHouse(houseId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
