using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CourseService : ICourseService
    {
        IRepository<Course> repository;
        public CourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }
        public async Task CreateCourse(Course course)
        {
            await repository.Create(course);
        }

        public async Task DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllourses()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourse(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
