using BusinessLogic.Models;
using BusinessLogic.Resources;
using FluentValidation;

namespace BusinessLogic.Validators
{
	public class MovieFindFilterModelValidator : AbstractValidator<MovieFindFilterModel>
	{
		public MovieFindFilterModelValidator()
		{

			RuleFor(x => x.Name)
				.Matches(@"^\p{Lu}.*")
					.WithMessage(ValidationErrors.StartUppercaseError)
					.When(x => !string.IsNullOrEmpty(x.Name));
		
			RuleFor(x => x.OriginalName)
				.Matches(@"^\p{Lu}.*")
				    .WithMessage(ValidationErrors.StartUppercaseError)
					.When(x => !string.IsNullOrEmpty(x.OriginalName));

			RuleFor(x => x.Years)
				.Must(x => x.All(z => z > 0))
					.WithMessage(ValidationErrors.GreaterZeroError)
					.When(x => x.Years != null && x.Years.Count != 0);

			RuleFor(x => x.Stafs)
				.Must(x => x.All(z => z > 0))
				    .WithMessage(ValidationErrors.GreaterZeroError)
					.When(x => x.Stafs != null && x.Stafs.Count != 0);

			RuleFor(x => x.Qualities)
				.Must(x => x.All(z => z > 0))
					.WithMessage(ValidationErrors.GreaterZeroError)
					.When(x => x.Qualities != null && x.Qualities.Count != 0);

			RuleFor(x => x.Genres)
				.Must(x => x.All(z => z > 0))
					.WithMessage(ValidationErrors.GreaterZeroError)
					.When(x => x.Genres != null && x.Genres.Count != 0);

			RuleFor(x => x.Countries)
				.Must(x => x.All(z => z > 0))
					.WithMessage(ValidationErrors.GreaterZeroError)
					.When(x => x.Countries != null && x.Countries.Count != 0);
				    
		}
	}
}
