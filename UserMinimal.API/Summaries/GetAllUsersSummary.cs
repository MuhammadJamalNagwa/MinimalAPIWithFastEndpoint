using FastEndpoints;
using UserMinimal.API.Endpoints;

namespace UserMinimal.API.Summaries;

public class GetAllUsersSummary : Summary<GetAllUsersEndpoint>
{
    public GetAllUsersSummary()
    {
        Summary = "Returns all the users in the system";
        Description = "Returns all the users in the system";
        Response<GetAllUsersEndpoint>(200, "All users in the system are returned");
    }
}
