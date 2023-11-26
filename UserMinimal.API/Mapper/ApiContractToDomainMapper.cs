using UserMinimal.API.Models;
using UserMinimal.API.Models.Common;
using UserMinimal.API.Requests;

namespace UserMinimal.API.Mapper;


public static class ApiContractToDomainMapper
{
    public static User ToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(Guid.NewGuid()),
            Email = EmailAddress.From(request.Email),
            Name = Name.From(request.Name),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static User ToUser(this UpdateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(request.Id),
            Email = EmailAddress.From(request.Email),
            Name = Name.From(request.Name),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
}
