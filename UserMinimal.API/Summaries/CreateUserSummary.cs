using FastEndpoints;
using UserMinimal.API.Endpoints;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Summaries;

public class CreateUserSummary : Summary<CreateUserEndpoint>
{
    public CreateUserSummary()
    {
        Summary = "Creates a new user in the system";
        Description = "Creates a new user in the system";
        Response<UserResponse>(201, "user was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
