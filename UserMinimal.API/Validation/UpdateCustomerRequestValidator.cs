using FluentValidation;
using UserMinimal.API.Requests;

namespace UserMinimal.API.Validation;

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}
