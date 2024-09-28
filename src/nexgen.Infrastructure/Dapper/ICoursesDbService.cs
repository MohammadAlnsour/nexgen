using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Infrastructure.Dapper
{
    public interface ICoursesDbService
    {
        public Task<Course> GetCourseById(int courseId);
    }
}
