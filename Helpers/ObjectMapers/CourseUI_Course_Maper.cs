using Interfaces;
using Models;
using Models.UI;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class CourseUI_Course_Maper : IMaper<CourseUI, Course>
    {
        IMaper<VideoUI, Video> videoMaper;
        IMaper<BookUI, Book> bookMaper;
        IMaper<ArticleUI, Article> articleMaper;
        public CourseUI_Course_Maper(IMaper<VideoUI, Video> videoMaper, IMaper<BookUI, Book> bookMaper, IMaper<ArticleUI, Article> articleMaper)
        {
            this.videoMaper = videoMaper;
            this.bookMaper = bookMaper;
            this.articleMaper = articleMaper;
        }
        public Course Map(CourseUI courseUI)
        {
            var materialVideos = courseUI.Videos.Select(v => new Material { Video = videoMaper.Map(v), MaterialTypeId = 1, Id = videoMaper.Map(v).MaterialId }).ToList();
            var materialArticles = courseUI.Articles.Select(a => new Material { Article = articleMaper.Map(a), MaterialTypeId = 2, Id = articleMaper.Map(a).MaterialId}).ToList();
            var materialBooks = courseUI.Books.Select(b => new Material { Book = bookMaper.Map(b), MaterialTypeId = 3, Id = bookMaper.Map(b).MaterialId}).ToList();
            var repoCourse = new Course();
            repoCourse.Materials = materialVideos;
            repoCourse.Materials.AddRange(materialBooks);
            repoCourse.Materials.AddRange(materialArticles);
            repoCourse.Name = courseUI.Name;
            repoCourse.Description = courseUI.Description;
            repoCourse.Skill = new Skill { Name = courseUI.Skill.Name};
            return repoCourse;
        }
    }
}
