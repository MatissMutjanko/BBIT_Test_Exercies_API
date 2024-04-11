using AutoMapper;
using BBIT_Test_Exercises_House;
using BBIT_Test_Exercises_House.Controllers;
using BBIT_Test_Exercises_House.DbContext;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace YourProject.Tests
{
    [TestFixture]
    public class ResidentControllerTests
    {
        private ResidentApiController _residentController;
        private Mock<IResidentService> _mockResidentService;
        private Mock<IApartmentService> _mockApartmentService;
        private IMapper _mapper;
        private AppDbContext _mockDbContext;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>().Object;
            _mockResidentService = new Mock<IResidentService>();
            _mockApartmentService = new Mock<IApartmentService>();
            _residentController =
                new ResidentApiController(_mapper, _mockResidentService.Object, _mockApartmentService.Object);
        }

        [Test]
        public void GetResident_WhenResidentDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var residentName = "Nonexistent Resident";
            var residentSurname = "Nonexistent Resident";

            _mockResidentService.Setup(service => service.GetByNameSurname(residentName, residentSurname))
                .Returns((Resident)null);

            // Act
            var result = _residentController.GetResident(residentName, residentSurname);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetResident_WhenResidentExists_ReturnsOkResult()
        {
            // Arrange
            var residentName = "Existing Resident";
            var residentSurname = "Existing Resident Surname";
            var existingResident = new Resident { Name = residentName, Surname = residentSurname };

            _mockResidentService.Setup(service => service.GetByNameSurname(residentName, residentSurname))
                .Returns(existingResident);

            // Act
            var result = _residentController.GetResident(residentName, residentSurname);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void DeleteResident_WhenResidentDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var residentName = "Nonexistent Resident";
            var residentSurname = "Nonexistent Resident";

            _mockResidentService.Setup(service => service.GetByNameSurname(residentName, residentSurname))
                .Returns((Resident)null);

            // Act
            var result = _residentController.DeleteResident(residentName, residentSurname);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddResident_WhenResidentIsUnique_ReturnsCreatedResult()
        {
            // Arrange
            var nonExistingResident = new Resident { Name = "Jane", Surname = "Smith" };
            _mockResidentService.Setup(service => service.IsResidentUnique(nonExistingResident)).Returns(true);

            // Act
            var result = _residentController.AddResident(nonExistingResident);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void AddResident_WhenResidentIsNotUnique_ReturnsConflictResult()
        {
            // Arrange
            var existingResident = new Resident { Name = "John", Surname = "Doe" };
            _mockResidentService.Setup(service => service.IsResidentUnique(existingResident)).Returns(false);

            // Act
            var result = _residentController.AddResident(existingResident);

            // Assert
            Assert.IsInstanceOf<ConflictResult>(result);
        }
    }
}