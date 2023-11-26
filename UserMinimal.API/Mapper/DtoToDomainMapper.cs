using UserMinimal.API.Dtos;
using UserMinimal.API.Models;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Mapper;

public static class DtoToDomainMapper
{
    public static User ToUser(this UserDto userDto)
    {
        return new User
        {
            Id = UserId.From(Guid.Parse(userDto.Id)),
            Email = EmailAddress.From(userDto.Email),
            Name = Name.From(userDto.Name),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(userDto.DateOfBirth))
        };
    }
}
