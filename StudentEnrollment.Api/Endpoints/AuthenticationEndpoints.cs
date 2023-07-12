using AutoMapper;
using StudentEnrollment.Api.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentEnrollment.Api.DTOs.Authentication;
using StudentEnrollment.Api.Services;
using StudentEnrollment.Api.DTOs;

namespace StudentEnrollment.Api.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api").WithTags("Authentication");

            group.MapPost("/login/", async Task<Results<Ok<AuthResponseDto>, UnauthorizedHttpResult>> (LoginDto loginDto, IAuthManager authManager) =>
            {
                var response = await authManager.Login(loginDto);
                if (response == null)
                {
                    return TypedResults.Unauthorized();
                }

                return TypedResults.Ok(response);
            })
            .WithName("Login")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();

            group.MapPost("/register/", async Task<Results<Ok, BadRequest<List<ErrorResponseDto>>>> (RegisterDto registerDto, IAuthManager authManager) =>
            {
                var response = await authManager.Register(registerDto);


                if (!response.Any())
                {
                    return TypedResults.Ok();
                }

                var errors = new List<ErrorResponseDto>();

                foreach (var error in response)
                {
                    errors.Add(new ErrorResponseDto
                    {
                        Code = error.Code,
                        Description = error.Description,
                    });
                }

                return TypedResults.BadRequest(errors);
            })
            .WithName("Register")
            .Produces(StatusCodes.Status200OK)
            .Produces (StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }
    }
}
