using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Helpers.Validators
{
	public class UserValidator : AbstractValidator<User>, Interfaces.IValidator<User>
    {
		public UserValidator()
		{
			RuleFor(x => x.Name).NotEmpty().NotNull().Length(3, 12);
			RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
			RuleFor(x => x.Password).NotEmpty().NotNull().Length(5, 15);
		}
		public new bool Validate(User user)
        {
			return base.Validate(user).IsValid;
        }
	}
}
