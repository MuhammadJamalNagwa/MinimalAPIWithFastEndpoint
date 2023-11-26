using UserMinimal.API.Models;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Mapper;

public static class DomainToApiContractMapper
{
    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id.Value,
            Email = user.Email.Value,
            Name = user.Name.Value,
            DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }

    public static GetAllUsersResponse ToUsersResponse(this IEnumerable<User> users)
    {
        return new GetAllUsersResponse
        {
            Users = users.Select(x => new UserResponse
            {
                Id = x.Id.Value,
                Email = x.Email.Value,
                Name = x.Name.Value,
                DateOfBirth = x.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }
}
