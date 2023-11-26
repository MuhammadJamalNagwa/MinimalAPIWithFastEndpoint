using ValueOf;

namespace UserMinimal.API.Models.Common;

public class UserId : ValueOf<Guid, UserId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Customer Id cannot be empty", nameof(UserId));
        }
    }
}
