﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.Api.DTOs.Course;
using AutoMapper;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Api.DTOs.Student;

namespace StudentEnrollment.Api.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (ICourseRepository repo, IMapper mapper) =>
        {
            var courses = await repo.GetAllAsync();
            return mapper.Map<List<CourseDto>>(courses);
        })
        .WithName("GetAllCourses")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CourseDto>, NotFound>> (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi();

        group.MapGet("/GetStudents/{id}", async Task<Results<Ok<CourseDetailsDto>, NotFound>> (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentList(id)
                is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDetailsDto>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, CourseDto courseDto, ICourseRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(courseDto, foundModel);
            await repo.UpdateAsync(foundModel);
            return TypedResults.Ok();

        })
        .WithName("UpdateCourse")
        .WithOpenApi();

        group.MapPost("/", async (CreateCourseDto courseDto, ICourseRepository repo, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(courseDto);
            await repo.AddAsync(course);
            return TypedResults.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ICourseRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi();
    }
}
