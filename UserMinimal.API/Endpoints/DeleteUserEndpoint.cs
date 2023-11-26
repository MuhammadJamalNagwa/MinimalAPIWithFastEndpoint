using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Models;
using UserMinimal.API.Requests;

namespace UserMinimal.API.Endpoints;

[HttpDelete("users/{id:guid}"), AllowAnonymous]
public class DeleteUserEndpoint : Endpoint<DeleteUserRequest>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        User userEntity = await _userRepository.GetByIdAsync(req.Id);

        if (userEntity is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        bool deleted = await _userRepository.DeleteAsync(userEntity);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
