using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(Course entity);
        Task<IEnumerable<Course>> GetAllourses();
        Task<Course> GetCourse(Course course);
        Task<Course> GetCourse(int id);
        Task UpdateCourse(Course entity);
        Task DeleteCourse(int id);
    }
}
