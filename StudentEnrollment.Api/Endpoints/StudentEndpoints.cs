using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using AutoMapper;
using StudentEnrollment.Api.DTOs.Student;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Api.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (IStudentRepository repo, IMapper mapper) =>
        {
            var students = await repo.GetAllAsync();
            return mapper.Map<List<StudentDto>>(students);
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StudentDto>, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapGet("/GetDetails/{id}", async Task<Results<Ok<StudentDetailsDto>, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDetailsDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentDto studentdto, IStudentRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(studentdto, foundModel);
            await repo.UpdateAsync(foundModel);
            return TypedResults.Ok();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (CreateStudentDto studentdto, IStudentRepository repo, IMapper mapper) =>
        {
            var student = mapper.Map<Student>(studentdto);
            await repo.AddAsync(student);
            return TypedResults.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, IStudentRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? TypedResults.Ok() : TypedResults.NotFound();

        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
