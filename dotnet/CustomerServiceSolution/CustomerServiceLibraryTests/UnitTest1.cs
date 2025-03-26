using CustomerServiceLibrary.DTO;
using CustomerServiceLibrary.Exceptions;
using CustomerServiceLibrary.Service;

namespace CustomerServiceLibraryTests
{
    public class Tests
    {
        private ICustomerService service;

        [SetUp]
        public void Setup()
        {
            service = new CustomerService();
        }

        [Test]
        public void RegisterCustomer_ForValidCustomer_ReturnsSuccessResponse()
        {
            // Arrange
            RegistrationRequestDto req = new()
            {
                Name="Vinod",
                Email="vinod@vinod.co",
                Phone="9731424784",
                City="Bangalore"
            };

            // Act
            var resp = service.RegisterCustomer(req);

            // Assert
            Assert.That(resp.Success, Is.True);
            Assert.That(resp.Id, Is.Not.Null);
            Assert.That(resp.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(resp.ErrorMessage, Is.Null);
        }

        [Test]
        public void RegisterCustomer_ForDuplicateCustomer_ReturnsFailResponse()
        {
            // Arrange
            RegistrationRequestDto req = new()
            {
                Name = "Vinod",
                Email = "vinod@vinod.co", // email already existing in our db
                Phone = "9731424784",
                City = "Bangalore"
            };

            // Act
            var resp = service.RegisterCustomer(req);

            // Assert
            Assert.That(resp.Success, Is.False);
            Assert.That(resp.Id, Is.Null);
            Assert.That(resp.ErrorMessage, Is.Not.Null);
            Assert.That(resp.ErrorMessage, Is.EqualTo("Customer with this email already registered."));
        }

        [Test]
        public void RegisterCustomer_ForNullInput_ThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => service.RegisterCustomer(null));
        }

        [Test]
        public void RegisterCustomer_ForNullName_ThrowsException()
        {
            // Arrange
            RegistrationRequestDto req = new();

            // Act + Assert
            Assert.Throws<InvalidCustomerDataException>(
                () => service.RegisterCustomer(req));

        }
    }
}