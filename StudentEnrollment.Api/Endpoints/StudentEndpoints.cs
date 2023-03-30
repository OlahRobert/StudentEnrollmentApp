using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using AutoMapper;
using StudentEnrollment.Api.DTOs.Student;

namespace StudentEnrollment.Api.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var students = await db.Students.ToListAsync();
            return mapper.Map<List<StudentDto>>(students);
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StudentDto>, NotFound>> (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            return await db.Students.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentDto studentdto, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.FirstName, studentdto.FirstName)
                  .SetProperty(m => m.LastName, studentdto.LastName)
                  .SetProperty(m => m.DateOfBirth, studentdto.DateOfBirth)
                  .SetProperty(m => m.IdNumber, studentdto.IdNumber)
                  .SetProperty(m => m.Picture, studentdto.Picture)
                  .SetProperty(m => m.Id, studentdto.Id)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (CreateStudentDto studentdto, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var student = mapper.Map<Student>(studentdto);
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
