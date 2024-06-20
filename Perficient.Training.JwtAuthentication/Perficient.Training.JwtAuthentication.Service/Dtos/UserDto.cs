using Perficient.Training.JwtAuthentication.Service.Enums;

namespace Perficient.Training.JwtAuthentication.Service.Dtos;

public record UserDto(string Name, string Email, string Password, UserRole Role);