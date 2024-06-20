using Perficient.Training.JwtAuthentication.Service.Enums;

namespace Perficient.Training.JwtAuthentication.Service.Models;

public class User
{
    public Guid Id  { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public UserRole Role { get; set; }
    public bool IsActiveRole { get; set; } = true;
}