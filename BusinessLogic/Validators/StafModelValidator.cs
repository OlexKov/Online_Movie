using BusinessLogic.ModelDto;
using BusinessLogic.Resources;
using FluentValidation;
using MimeKit.Cryptography;



namespace BusinessLogic.Validators
{
	public class StafModelValidator : AbstractValidator<StafModel>
	{
		public StafModelValidator()
        {
            RuleFor(x => x.Id)
				 .NotNull().WithMessage(ValidationErrors.NotEmpty)
				 .GreaterThanOrEqualTo(0).WithMessage(ValidationErrors.GreaterEqualZeroError);
            RuleFor(x=>x.Birthdate)
                .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
                .LessThan(DateTime.Now).WithMessage(ValidationErrors.BirthdateError);
            RuleFor(x => x.Name)
				 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
                 .Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.Surname)
				 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				 .Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.Description)
				 .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				 .MinimumLength(20).WithMessage($"{ValidationErrors.SymbolsCountError} 20 symbols");
			//RuleFor(x => x.ImageFile)
			//.NotNull()
			//.When(x => String.IsNullOrEmpty(x.ImageName), ApplyConditionTo.CurrentValidator)
			//.WithMessage(ValidationErrors.ImageEmptyError);
			RuleFor(x => x.IsOscar)
							 .NotNull().WithMessage(ValidationErrors.NotEmpty);
			RuleFor(x=>x.Roles)
				.Must(collection => collection != null && collection.Count != 0)
	            .WithMessage(ValidationErrors.NotEmpty);
			RuleFor(x => x.CountryId)
				 .Must(x=>x != null && x > 0)
				 .WithMessage(ValidationErrors.NotEmpty);
			
		}
    }
}
