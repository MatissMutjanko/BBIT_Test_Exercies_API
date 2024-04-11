using AutoMapper;
using BBIT_Test_Exercises_House;
using BBIT_Test_Exercises_House.Controllers;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace YourProject.Tests
{
    [TestFixture]
    public class ApartmentControllerTests
    {
        private ApartmentApiController _apartmentController;
        private Mock<IApartmentService> _mockApartmentService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>().Object;
            _mockApartmentService = new Mock<IApartmentService>();
            _apartmentController = new ApartmentApiController(_mapper, _mockApartmentService.Object);
        }

        [Test]
        public void AddApartment_WhenApartmentIsUnique_ReturnsCreatedResult()
        {
            // Arrange
            var apartment = new Apartment { Id = 1, Floor = 2, NumberOfRooms = 3, FloorSpace = 100, LivingSpace = 80 };
            _mockApartmentService.Setup(service => service.GetById(apartment.Id)).Returns((Apartment)null);

            // Act
            var result = _apartmentController.AddApartment(apartment);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void AddApartment_WhenApartmentIsNotUnique_ReturnsConflictResult()
        {
            // Arrange
            var existingApartment = new Apartment { Id = 1, Floor = 2, NumberOfRooms = 3, FloorSpace = 100, LivingSpace = 80 };
            _mockApartmentService.Setup(service => service.GetById(existingApartment.Id)).Returns(existingApartment);

            // Act
            var result = _apartmentController.AddApartment(existingApartment);

            // Assert
            Assert.IsInstanceOf<ConflictResult>(result);
        }

        [Test]
        public void GetApartment_WhenApartmentExists_ReturnsOkResult()
        {
            // Arrange
            var apartmentId = 1;
            var existingApartment = new Apartment { Id = apartmentId, Floor = 2, NumberOfRooms = 3, FloorSpace = 100, LivingSpace = 80};
            _mockApartmentService.Setup(service => service.GetById(apartmentId)).Returns(existingApartment);

            // Act
            var result = _apartmentController.GetApartment(apartmentId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetApartment_WhenApartmentDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var apartmentId = 1;
            _mockApartmentService.Setup(service => service.GetById(apartmentId)).Returns((Apartment)null);

            // Act
            var result = _apartmentController.GetApartment(apartmentId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void DeleteApartment_WhenApartmentExists_ReturnsOkResult()
        {
            // Arrange
            var apartmentId = 1;
            var existingApartment = new Apartment { Id = apartmentId, Floor = 2, NumberOfRooms = 3, FloorSpace = 100, LivingSpace = 80 };
            _mockApartmentService.Setup(service => service.GetById(apartmentId)).Returns(existingApartment);

            // Act
            var result = _apartmentController.DeleteApartment(apartmentId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void DeleteApartment_WhenApartmentDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var apartmentId = 1;
            _mockApartmentService.Setup(service => service.GetById(apartmentId)).Returns((Apartment)null);

            // Act
            var result = _apartmentController.DeleteApartment(apartmentId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
