using AutoMapper;
using StudentEnrollment.Api.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentEnrollment.Api.DTOs.Authentication;
using StudentEnrollment.Api.Services;

namespace StudentEnrollment.Api.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/login").WithTags("Authentication");

            group.MapPost("/", async Task<Results<Ok<AuthResponseDto>, UnauthorizedHttpResult>> (LoginDto loginDto, IAuthManager authManager) =>
            {
                var response = await authManager.Login(loginDto);
                if (response == null)
                {
                    return TypedResults.Unauthorized();
                }

                return TypedResults.Ok(response);
            })
            .WithName("Login")
            .WithOpenApi();
        }
    }
}
