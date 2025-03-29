using CustomerServiceLibrary.DTO;
using CustomerServiceLibrary.Exceptions;
using CustomerServiceLibrary.Model;

namespace CustomerServiceLibrary.Service
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = [];

        public RegistrationResponseDto RegisterCustomer(RegistrationRequestDto dto)
        {
            if(dto.Name == null)
            {
                throw new InvalidCustomerDataException();
            }

            // convert the DTO into a model object 
            // this is the one being persisted into the DB
            Customer cust = new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                City = dto.City
            };

            customers.Add(cust);

            return new RegistrationResponseDto()
            {
                Success = true,
                Id = cust.Id
            };


            throw new NotImplementedException();
        }
    }
}
