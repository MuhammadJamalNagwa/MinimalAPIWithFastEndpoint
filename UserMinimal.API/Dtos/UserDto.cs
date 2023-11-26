namespace UserMinimal.API.Dtos;

public sealed class UserDto
{
    public string Name { get; init; } = default!;

    public string Id { get; init; } = default!;

    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }
}
