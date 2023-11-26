using FastEndpoints;
using UserMinimal.API.Endpoints;

namespace UserMinimal.API.Summaries;

public class DeleteUserSummary : Summary<DeleteUserEndpoint>
{
    public DeleteUserSummary()
    {
        Summary = "Deleted a user the system";
        Description = "Deleted a user the system";
        Response(204, "The user was deleted successfully");
        Response(404, "The user was not found in the system");
    }
}
