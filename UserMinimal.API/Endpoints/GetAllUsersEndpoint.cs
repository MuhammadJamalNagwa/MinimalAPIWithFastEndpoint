using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Mapper;
using UserMinimal.API.Models;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Endpoints;

[HttpGet("users"), AllowAnonymous]
public class GetAllUsersEndpoint : EndpointWithoutRequest<GetAllUsersResponse>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<User> users = await _userRepository.GetAllAsync();
        GetAllUsersResponse usersResponse = users.ToUsersResponse();
        await SendOkAsync(usersResponse, ct);
    }
}
