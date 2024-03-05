using BusinessLogic.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
	public class RegisterUserModelValidator : AbstractValidator<RegisterUserModel>
	{
		private readonly string notBeEmpty = "{PropertyName} not be empty";
		public RegisterUserModelValidator()
        {
			RuleFor(x => x.Birthdate)
					.NotEmpty().WithMessage(notBeEmpty)
					.LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than today");
			RuleFor(x => x.Name)
					 .NotEmpty().WithMessage(notBeEmpty)
					 .Matches(@"^\p{Lu}.*").WithMessage("{PropertyName} must start with uppercase leter");
			RuleFor(x => x.Surname)
					 .NotEmpty().WithMessage(notBeEmpty)
					 .Matches(@"^\p{Lu}.*").WithMessage("{PropertyName} must start with uppercase leter");
			RuleFor(x => x.Email)
					 .NotEmpty().WithMessage(notBeEmpty)
					 .EmailAddress();
			RuleFor(x => x.PremiumId)
				     .NotNull().WithMessage(notBeEmpty)
				     .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater zero");
		}
        
	}
}
