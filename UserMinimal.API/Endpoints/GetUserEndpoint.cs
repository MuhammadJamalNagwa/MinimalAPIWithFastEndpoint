using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Mapper;
using UserMinimal.API.Models;
using UserMinimal.API.Requests;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Endpoints;

[HttpGet("users/{id:guid}"), AllowAnonymous]
public class GetUserEndpoint : Endpoint<GetUserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        User userEntity = await _userRepository.GetByIdAsync(req.Id);

        if (userEntity is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        UserResponse userResponse = userEntity.ToUserResponse();
        await SendOkAsync(userResponse, ct);
    }
}
