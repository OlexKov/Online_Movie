using BusinessLogic.Models;
using BusinessLogic.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
	public class EditUserModelValidator : AbstractValidator<EditUserModel>
	{
		public EditUserModelValidator() 
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
			RuleFor(x => x.PhoneNumber)
					 .Matches(@"^\d{3}[-\s]{1}\d{3}[-\s]{1}\d{2}[-\s]{0,1}\d{2}$")
					 .WithMessage(ValidationErrors.InvalidPhoneNumber);
			RuleFor(x => x.Email)
				     .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
					 .EmailAddress().WithMessage(ValidationErrors.InvalidEmail);
			RuleFor(x => x.Password)
					 .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?([^\w\s]|[_])).{6,}$")
					 .WithMessage(ValidationErrors.InvalidPassword);
			RuleFor(x => x.NewPassword)
					 .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?([^\w\s]|[_])).{6,}$")
					 .WithMessage(ValidationErrors.InvalidPassword);
		}
	}
}
