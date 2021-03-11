using Models;
using Models.UI;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CourseUI materials);
        Task AddCourseForUser(int courseId, int userId);
        Task<IEnumerable<CourseUI>> SearchAllCourses(string name, int page);
        Task<IEnumerable<CourseUI>> GetAllUserCourses(int userId, int page);
        Task<bool> IfCourseExists(int id);

        Task<AllMaterials> GetMaterials(int page);
        Task AddCompletedMaterials(IEnumerable<int> coursesId, int userId);
        Task<IEnumerable<SkillUI>> GetSkills(int page);
    }
}
