using BusinessLogic.ModelDto;
using BusinessLogic.Resources;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class MovieModelValidator : AbstractValidator<MovieModel>
	{
		public MovieModelValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				.Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.OriginalName)
				.NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				.Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.DateDuration)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .LessThan(DateTime.Now).WithMessage(ValidationErrors.BirthdateError);
			RuleFor(x => x.Description)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .MinimumLength(20).WithMessage($"{ValidationErrors.SymbolsCountError} 20 symbols");
			RuleFor(x => x.QualityId)
			   .GreaterThan(0).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.CountryId)
			   .GreaterThan(0).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.PosterFile)
			   .NotNull().WithMessage(ValidationErrors.NotEmpty)
			   .When(x => String.IsNullOrEmpty(x.Poster), ApplyConditionTo.CurrentValidator)
			   .WithMessage(ValidationErrors.ImageEmptyError);
			RuleFor(x => x.MovieUrl)
			   .NotNull().WithMessage(ValidationErrors.NotEmpty);
			   //.Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
			   // .WithMessage(ValidationErrors.InvalidUrl);
			RuleFor(x => x.TrailerUrl)
			   .NotNull().WithMessage(ValidationErrors.NotEmpty);
			  // .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
			  // .WithMessage(ValidationErrors.InvalidUrl);
			RuleFor(x => x.PremiumId)
			   .GreaterThan(0).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Stafs)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .Must(x => x.Count > 0).WithMessage(ValidationErrors.NotEmpty);
			RuleFor(x => x.ScreenShots)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .When(x=>x.Screens == null || x.Screens.Count == 0, ApplyConditionTo.CurrentValidator);
			RuleFor(x => x.Screens)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .When(x => x.ScreenShots == null || x.ScreenShots.Count == 0, ApplyConditionTo.CurrentValidator);
			RuleFor(x => x.Genres)
			   .NotEmpty().WithMessage(ValidationErrors.NotEmpty)
			   .Must(x => x.Count > 0).WithMessage(ValidationErrors.NotEmpty);
			
		}
	}
}
