using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Models;

public class User
{
    public UserId Id { get; init; } = UserId.From(Guid.NewGuid());

    public Name Name { get; init; } = default!;

    public EmailAddress Email { get; init; } = default!;
    public DateOfBirth DateOfBirth { get; init; } = default!;
}