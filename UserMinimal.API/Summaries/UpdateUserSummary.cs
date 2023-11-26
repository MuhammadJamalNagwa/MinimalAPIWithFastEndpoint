using FastEndpoints;
using UserMinimal.API.Endpoints;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Summaries;

public class UpdateUserSummary : Summary<UpdateUserEndpoint>
{
    public UpdateUserSummary()
    {
        Summary = "Updates an existing customer in the system";
        Description = "Updates an existing customer in the system";
        Response<UserResponse>(201, "Customer was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
