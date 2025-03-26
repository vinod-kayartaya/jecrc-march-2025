namespace CustomerServiceLibrary.DTO
{
    public class RegistrationResponseDto
    {
        public bool Success { get; set; }
        public Guid? Id { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
