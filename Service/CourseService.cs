using FluentValidation.Validators;
using Interfaces;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Models;
using Models.UI;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CourseService : ICourseService
    {
        IRepository<Course> courseRepository;
        IRepository<Video> videoRepository;
        IRepository<Book> bookRepository;
        IRepository<Article> articleRepository;
        IRepository<User> userRepository;
        IRepository<Material> materialRepository;
        IRepository<Skill> skillRepository;
        IMaper<CourseUI, Course> courseMaper;
        IMaper<List<Course>, List<CourseUI>> courseListMaperUI;
        IMaper<List<Material>, List<VideoUI>> videoMaper;
        IMaper<List<Material>, List<ArticleUI>> articleMaper;
        IMaper<List<Material>, List<BookUI>> bookMaper;
        IMaper<List<Skill>, List<SkillUI>> skillListMaper;
        public CourseService(IRepository<Skill> skillRepository, IMaper<List<Skill>, List<SkillUI>> skillListMaper, IMaper<List<Material>, List<VideoUI>> videoMaper, IMaper<List<Material>, List<ArticleUI>> articleMaper, IMaper<List<Material>, List<BookUI>> bookMaper, IMaper<CourseUI, Course> courseMaper, IMaper<List<Course>, List<CourseUI>> courseListMaperUI, IRepository<Material> materialRepository, IRepository<User> userRepository, IRepository<Video> videoRepository, IRepository<Book> bookRepository, IRepository<Article> articleRepository, IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
            this.bookRepository = bookRepository;
            this.videoRepository = videoRepository;
            this.articleRepository = articleRepository;
            this.userRepository = userRepository;
            this.courseMaper = courseMaper;
            this.courseListMaperUI = courseListMaperUI;
            this.materialRepository = materialRepository;
            this.videoMaper = videoMaper;
            this.articleMaper = articleMaper;
            this.bookMaper = bookMaper;
            this.skillRepository = skillRepository;
            this.skillListMaper = skillListMaper;
        }
        public async Task CreateCourse(CourseUI courseUI)
        {
            var course = courseMaper.Map(courseUI);
            var skill = await skillRepository.Read(skill => skill.Name == course.Skill.Name);
            if(skill != null)
            {
                course.Skill = skill;
            }
            //var existedMaterials = (await materialRepository.ReadAll(material => courseRepo.Materials.Contains(material))).ToList();
            var resultMaterials = new List<Material>();
            foreach (var material in course.Materials)
            {
                var existingMaterial = await materialRepository.Read(m => m.Id == material.Id);
                if(existingMaterial != null)
                {
                    resultMaterials.Add(existingMaterial);
                }
                else
                {
                    resultMaterials.Add(material);
                }
            }
            course.Materials = resultMaterials;
            await courseRepository.Update(course);
            await courseRepository.SaveChanges();
        }
        public async Task AddCourseForUser(int courseId, int userId)
        {
            var user = await userRepository.Read(z => z.Id == userId, includeProperty: "Courses");
            var course = await courseRepository.Read(course => course.Id == courseId);
            user.Courses.Add(course);
            await userRepository.Update(user);
            await userRepository.SaveChanges();
        }
        public async Task<AllMaterials> GetMaterials(int page)
        {
            var videos = (await videoRepository.PagingReadAll(page)).ToList();
            var articles = (await articleRepository.PagingReadAll(page)).ToList();
            var books = (await bookRepository.PagingReadAll(page)).ToList();
            return new AllMaterials { Videos = videos, Articles = articles, Books = books };
        }


        public async Task<IEnumerable<CourseUI>> SearchAllCourses(string name, int page)
        {
            var courses = (await courseRepository.PagingReadAll(x => x.Name == name, page, includeProperty: "Materials")).ToList();
            foreach (var course in courses)
            {
                  foreach (var material in course.Materials)
                  {
                    material.Video = await videoRepository.Read(video => video.MaterialId == material.Id && video.Material.MaterialTypeId == 1);
                    material.Article = await articleRepository.Read(article => article.MaterialId == material.Id && article.Material.MaterialTypeId == 2);
                    material.Book = await bookRepository.Read(book => book.MaterialId == material.Id && book.Material.MaterialTypeId == 3);
                  }
            }
            return courseListMaperUI.Map(courses.ToList());
        }
        public async Task<IEnumerable<CourseUI>> GetAllUserCourses(int userId, int page)
        {
            var courses = (await courseRepository.PagingReadAll(course => course.Users.Any(user => user.Id == userId), page)).ToList();
            var user = await userRepository.Read(user => user.Id == userId, includeProperty: "UserMaterials");
            var coursesUI = courseListMaperUI.Map(courses);
            foreach (var courseUI in coursesUI) 
            {
                var videos = (await materialRepository.PagingReadAll(material => material.Courses.Any(course => course.Id == courseUI.Id), page, includeProperty: "Video")).Where(material => material.Video != null).ToList();
                var articles = (await  materialRepository.PagingReadAll(material => material.Courses.Any(course => course.Id == courseUI.Id), page, includeProperty: "Article")).Where(material => material.Article != null).ToList();
                var books = (await materialRepository.PagingReadAll(material => material.Courses.Any(course => course.Id == courseUI.Id), page, includeProperty: "Book")).Where(material => material.Book != null).ToList();
                courseUI.Videos = videoMaper.Map(videos);
                courseUI.Articles = articleMaper.Map(articles);
                courseUI.Books = bookMaper.Map(books);
                courseUI.Videos.Where(v => user.UserMaterials.Any(um => um.MaterialId == v.MaterialId)).ToList().ForEach(v => v.IsCompleted = true);
                courseUI.Articles.Where(a => user.UserMaterials.Any(um => um.MaterialId == a.MaterialId)).ToList().ForEach(a => a.IsCompleted = true);
                courseUI.Books.Where(b => user.UserMaterials.Any(um => um.MaterialId == b.MaterialId)).ToList().ForEach(b => b.IsCompleted = true);
            }
            return coursesUI;
        }
        public async Task<IEnumerable<SkillUI>> GetSkills(int page)
        {
            var skills =  await skillRepository.PagingReadAll(page);
            var skillsUI = skillListMaper.Map(skills.ToList());
            return skillsUI.ToList();
        }
        public async Task AddCompletedMaterials(IEnumerable<int> materialsId, int userId)
        {
            var user = await userRepository.Read(user => user.Id == userId, includeProperty: "UserMaterials");
            var userMaterials = new List<UserMaterial>();
            foreach(int materialId in materialsId)
            {
                userMaterials.Add(new UserMaterial { UserId = userId, MaterialId = materialId });
            }
            user.UserMaterials.AddRange(userMaterials);
            await userRepository.Update(user);
            await userRepository.SaveChanges();
        }


        public async Task<bool> IfCourseExists(int id)
        {
            var course = await courseRepository.Read(id);
            if(course != null)
            {
                return true;
            }
            return false;
        }
    }
}
