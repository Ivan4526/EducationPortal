using FluentValidation;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Validators
{
    public class BookValidator : AbstractValidator<BookUI>, Interfaces.IValidator<BookUI>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Pages).NotEmpty().NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(2000);
            RuleFor(x => x.PublishDate).NotEmpty().NotNull().Must(BeAValidDate);
        }
        private bool BeAValidDate(DateTime date)
        {
            var defaultDate = default(DateTime);
            return !date.Equals(defaultDate);
        }
        public new bool Validate(BookUI courseUI)
        {
            return base.Validate(courseUI).IsValid;
        }
    }
}
