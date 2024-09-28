using nexgen.Domain.Entities;
using nexgen.Infrastructure.Dapper;
using nexgen.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Infrastructure.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ICoursesDbService coursesDbService;

        public CoursesRepository(ICoursesDbService coursesDbService)
        {
            this.coursesDbService = coursesDbService;
        }
        public Task<bool> Delete(Course entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> Get(int id)
        {
            return await coursesDbService.GetCourseById(id);
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetPaged(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<long> Insert(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
