using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
	{
        public ForgotPasswordModelValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email address.");
        }
    }
}
