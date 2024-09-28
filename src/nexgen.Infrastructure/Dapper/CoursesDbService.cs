using Microsoft.Extensions.Configuration;
using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace nexgen.Infrastructure.Dapper
{
    public class CoursesDbService : ICoursesDbService
    {
        private readonly IConfiguration _configuration;
        public CoursesDbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            var connectionString = _configuration.GetConnectionString("ReadConnection");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string sql = @"
                            SELECT * FROM [materials].[Courses] WHERE Id = @CourseId;
                            SELECT * FROM [materials].[Chapters] WHERE CourseId = @CourseId;
                            SELECT Instructors.* FROM [materials].[Instructors] JOIN [materials].[Courses] ON [Courses].InstructorId = Instructors.Id WHERE [Courses].Id = @CourseId
                            SELECT * FROM [materials].Lessons WHERE CourseId = @CourseId
";

                    await connection.OpenAsync();

                    var course = new Course();

                    using (var query = connection.QueryMultiple(sql, new { CourseId = courseId }))
                    {
                        var dbcourse = query.ReadFirst<Course>();
                        var courseChapters = query.Read<Chapter>().ToList();
                        var instructor = query.ReadFirst<Instructor>();
                        var lessons = query.Read<Lesson>().ToList();

                        course.SetInstructor(instructor, instructor.Id);
                        course.SetBasic(dbcourse.CourseName, dbcourse.CourseImage, dbcourse.CourseStartDate, dbcourse.CourseEndDate);

                        foreach (var chapter in courseChapters)
                        {
                            if (lessons.Any(lesson => lesson.ChapterId == chapter.Id))
                            {
                                var chapterLessons = lessons.Where(lesson => lesson.ChapterId == chapter.Id).ToList();
                                chapter.Lessons = chapterLessons;
                            }
                            else
                                chapter.Lessons = new List<Lesson>();
                        }

                        course.SetChapters(courseChapters);
                    }

                    return course;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var connectionString = _configuration.GetConnectionString("ReadConnection");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT [Courses].*, [Instructors].InstructorName  FROM [materials].[Courses] JOIN [materials].[Instructors] ON [Courses].InstructorId = Instructors.Id";
                    await connection.OpenAsync();

                    var courses = connection.Query<Course>(sql).ToList();
                    return courses;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
