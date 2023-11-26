namespace UserMinimal.API.Requests;

public sealed class CreateUserRequest
{
    public string Name { get; init; }
    public string Email { get; init; }
    public DateTime DateOfBirth { get; init; }
}
