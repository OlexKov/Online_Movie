using BusinessLogic.ModelDto;
using BusinessLogic.Resources;
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
		public RegisterUserModelValidator()
        {
			RuleFor(x => x.Birthdate)
					.NotEmpty().WithMessage(ValidationErrors.NotEmpty)
					.LessThan(DateTime.Now).WithMessage(ValidationErrors.BirthdateError);
			RuleFor(x => x.Name)
					 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
					 .Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.Surname)
					 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
					 .Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.Email)
					 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
					 .EmailAddress();
		}
        
	}
}
