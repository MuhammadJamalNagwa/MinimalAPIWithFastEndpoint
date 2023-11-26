using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace UserMinimal.API.Models.Common;

public class Name : ValueOf<string, Name>
{
    private static readonly Regex NameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!NameRegex.IsMatch(Value))
        {
            string? message = $"{Value} is not a valid full name";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Name), message)
            });
        }
    }
}
