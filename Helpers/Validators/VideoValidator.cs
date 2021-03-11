using FluentValidation;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Validators
{
   public class VideoValidator : AbstractValidator<VideoUI>, Interfaces.IValidator<VideoUI>
    {
        public VideoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Duration).NotEmpty().NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(2000);
            RuleFor(x => x.Quality).NotEmpty().NotNull().Length(5, 20);
        }
        public new bool Validate(VideoUI videoUI)
        {
            return base.Validate(videoUI).IsValid;
        }
    }
}
