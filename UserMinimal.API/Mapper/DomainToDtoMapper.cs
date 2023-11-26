using UserMinimal.API.Dtos;
using UserMinimal.API.Models;

namespace UserMinimal.API.Mapper;

public static class DomainToDtoMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id.Value.ToString(),
            Email = user.Email.Value,
            Name = user.Name.Value,
            DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
}
