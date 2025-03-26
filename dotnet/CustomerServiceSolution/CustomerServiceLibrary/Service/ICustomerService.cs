using CustomerServiceLibrary.DTO;

namespace CustomerServiceLibrary.Service
{
    public interface ICustomerService
    {
        public RegistrationResponseDto RegisterCustomer(RegistrationRequestDto dto);
    }
}
