using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Data.Converters;

public class EmailAddressConverter : ValueConverter<EmailAddress, string>
{
    public EmailAddressConverter()
        : base(
            v => v.Value,
            v => EmailAddress.From(v))
    {
    }
}
