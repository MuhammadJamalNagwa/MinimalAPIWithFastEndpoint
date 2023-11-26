using FastEndpoints;
using UserMinimal.API.Endpoints;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Summaries;

public class GetUserSummary : Summary<GetUserEndpoint>
{
    public GetUserSummary()
    {
        Summary = "Returns a single user by id";
        Description = "Returns a single user by id";
        Response<UserResponse>(200, "Successfully found and returned the user");
        Response(404, "The customer does not exist in the system");
    }
}
