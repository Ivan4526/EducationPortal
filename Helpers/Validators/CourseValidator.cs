using FluentValidation;
using Models;
using Models.UI;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Validators
{
    public class CourseValidator : AbstractValidator<CourseUI>, Interfaces.IValidator<CourseUI>
    {
        Interfaces.IValidator<ArticleUI> articleValidator;
        Interfaces.IValidator<BookUI> bookValidator;
        Interfaces.IValidator<VideoUI> videoValidator;
        public CourseValidator(Interfaces.IValidator<ArticleUI> articleValidator, Interfaces.IValidator<BookUI> bookValidator, Interfaces.IValidator<VideoUI> videoValidator)
        {
            this.articleValidator = articleValidator;
            this.bookValidator = bookValidator;
            this.videoValidator = videoValidator;
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Description).NotEmpty().NotNull().Length(25, 150);
           // RuleFor(x => x.Skill.Name).NotEmpty().NotNull().Length(5, 20);
        }
        public new bool Validate(CourseUI courseUI)
        {
            foreach(var article in courseUI.Articles)
            {
                if (!articleValidator.Validate(article))
                    return false;
            }
            foreach(var video in courseUI.Videos)
            {
                if (!videoValidator.Validate(video))
                    return false;
            }
            foreach(var book in courseUI.Books)
            {
                if (!bookValidator.Validate(book))
                    return false;
            }
            var result = base.Validate(courseUI);
            return result.IsValid;
        }
    }
}
