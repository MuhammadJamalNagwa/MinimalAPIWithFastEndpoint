using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Data.Converters;

public class UserIdConverter : ValueConverter<UserId, Guid>
{
    public UserIdConverter()
        : base(
            v => v.Value,
            v => UserId.From(v))
    {
    }
}
