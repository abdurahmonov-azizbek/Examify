namespace Examify.Domain.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public bool IsAdmin { get; set; }
}