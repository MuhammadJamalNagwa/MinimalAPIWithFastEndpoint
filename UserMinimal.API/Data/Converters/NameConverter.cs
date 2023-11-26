using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Data.Converters;

public class NameConverter : ValueConverter<Name, string>
{
    public NameConverter()
        : base(
            v => v.Value,
            v => Name.From(v))
    {
    }
}
