using BusinessLogic.ModelDto;
using BusinessLogic.Resources;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
	{
        public ResetPasswordModelValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
                .EmailAddress().WithMessage(ValidationErrors.InvalidEmail);
			RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage($"{ValidationErrors.SymbolsCountError} 6 symbols")
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?([^\\w\\s]|[_])).{6,}$").WithMessage(ValidationErrors.InvalidPassword);
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage(ValidationErrors.NotEmpty);

        }

    }
}
