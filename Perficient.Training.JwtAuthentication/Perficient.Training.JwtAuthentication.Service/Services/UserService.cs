using Bogus;
using Perficient.Training.JwtAuthentication.Service.Dtos;
using Perficient.Training.JwtAuthentication.Service.Enums;
using Perficient.Training.JwtAuthentication.Service.Models;
using Perficient.Training.JwtAuthentication.Service.Services.Interfaces;

namespace Perficient.Training.JwtAuthentication.Service.Services;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new Faker<User>()
            .RuleFor(o => o.Name, f => f.Person.FullName)
            .RuleFor(o => o.Email, f => f.Person.Email)
            .RuleFor(o => o.Password, f => f.Random.AlphaNumeric(8))
            .RuleFor(o => o.CreatedAt, f => f.Date.Past(15))
            .RuleFor(o => o.Role, f => f.Random.Enum<UserRole>())
            .Generate(3);
    }

    public async Task<User> CreateUserAsync(UserDto user)
    {
        var newUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = DateTime.Now,
            Role = user.Role
        };

        _users.Add(newUser);

        return await Task.FromResult(newUser);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await GetUserAsync(id);

        if (user is null) return;

        user.IsActiveRole = false;
    }

    public async Task<User?> GetUserAsync(Guid id)
    {
        return await Task.FromResult(_users.FirstOrDefault(user => user.Id.Equals(id)));
    }

    public async Task<IReadOnlyCollection<User>> GetUsersAsync()
    {
        return await Task.FromResult(_users.AsReadOnly());
    }

    public async Task UpdateUserAsync(Guid id, UserDto user)
    {
        var userToUpdate = await GetUserAsync(id);

        if (userToUpdate is null) return;

        userToUpdate.Email = user.Email;
        userToUpdate.Name = user.Name;
        userToUpdate.Password = user.Password;
        userToUpdate.Role = user.Role;
    }
}