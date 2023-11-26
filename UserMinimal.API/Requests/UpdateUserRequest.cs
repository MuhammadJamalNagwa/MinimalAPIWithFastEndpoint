namespace UserMinimal.API.Requests;

public sealed class UpdateUserRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }
}
