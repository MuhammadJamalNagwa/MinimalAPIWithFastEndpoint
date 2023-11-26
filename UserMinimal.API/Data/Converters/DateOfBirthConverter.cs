using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Data.Converters;

public class DateOfBirthConverter : ValueConverter<DateOfBirth, DateOnly>
{
    public DateOfBirthConverter()
        : base(
            v => v.Value,
            v => DateOfBirth.From(v))
    {
    }
}
