using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Dtos
{
    public record EmployeeDto
    {
        public Guid Id { get; init; }
        public Guid CinemaTheaterId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime DateOfBirth { get; init; }
        public EEmployeeRole Role { get; init; }
    }
}
