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
    public class Course_CourseUI_Maper : IMaper<Course, CourseUI>
    {
        IMaper<Video, VideoUI> videoMaper;
        IMaper<Book, BookUI> bookMaper;
        IMaper<Article, ArticleUI> articleMaper;
        public Course_CourseUI_Maper(IMaper<Video, VideoUI> videoMaper, IMaper<Book, BookUI> bookMaper, IMaper<Article, ArticleUI> articleMaper)
        {
            this.videoMaper = videoMaper;
            this.bookMaper = bookMaper;
            this.articleMaper = articleMaper;
        }
        public CourseUI Map(Course courseRepo)
        {
            var courseUI = new CourseUI();
            courseUI.Videos = new List<VideoUI>();
            courseUI.Articles = new List<ArticleUI>();
            courseUI.Books = new List<BookUI>();
            if (courseRepo.Materials != null)
            {
                foreach (var material in courseRepo.Materials)
                {
                    courseUI.Videos.Add(videoMaper.Map(material.Video));
                    courseUI.Articles.Add(articleMaper.Map(material.Article));
                    courseUI.Books.Add(bookMaper.Map(material.Book));
                }
            }
            courseUI.Description = courseRepo.Description;
            courseUI.Name = courseRepo.Name;
            courseUI.Id = courseRepo.Id;
            return courseUI;
        }
    }
}
