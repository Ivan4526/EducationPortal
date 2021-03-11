using FluentValidation;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Validators
{
    public class ArticleValidator : AbstractValidator<ArticleUI>, Interfaces.IValidator<ArticleUI>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.URL).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.PublishDate).NotEmpty().NotNull().Must(BeAValidDate);
        }
        private bool BeAValidDate(DateTime date)
        {
            var defaultDate = default(DateTime);
            return !date.Equals(defaultDate);
        }
        public new bool Validate(ArticleUI articleUI)
        {
            return base.Validate(articleUI).IsValid;
        }
    }
}
