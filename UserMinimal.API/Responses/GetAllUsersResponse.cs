namespace UserMinimal.API.Responses;

public sealed class GetAllUsersResponse
{
    public IEnumerable<UserResponse> Users { get; init; } = Enumerable.Empty<UserResponse>();

}
