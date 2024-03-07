using BusinessLogic.ModelDto;
using BusinessLogic.Resources;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
	{
        public ResetPasswordModelValidator()
        {
            RuleFor(x=>x.UserId)
                .NotEmpty()
				.WithMessage(ValidationErrors.NotEmpty);
			RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage($"{ValidationErrors.SymbolsCountError} 6 symbols")
                .Matches("").WithMessage(ValidationErrors.InvalidPassword);
            RuleFor(x => x.ConfirmPassword)
                .Must((model, fild) => model.Password == fild)
                .WithMessage(ValidationErrors.NotMatchPasswordsError);
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage(ValidationErrors.NotEmpty);
        }

    }
}
