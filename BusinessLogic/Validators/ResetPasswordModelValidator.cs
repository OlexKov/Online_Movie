using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
	{
        public ResetPasswordModelValidator()
        {
            RuleFor(x=>x.UserId)
                .NotEmpty()
				.WithMessage("UserId cannot be empty.");
			RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must contain minimum 6 symbols.")
                .Matches("").WithMessage("Invalid password.");
            RuleFor(x => x.ConfirmPassword)
                .Must((model, fild) => model.Password == fild)
                .WithMessage("Passwords do not match");
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token cannot be empty.");
        }

    }
}
