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
	public class MovieFindFilterModelValidator : AbstractValidator<MovieFindFilterModel>
	{
		public MovieFindFilterModelValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				.Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.OriginalName)
				.NotEmpty().WithMessage(ValidationErrors.NotEmpty)
				.Matches(@"^\p{Lu}.*").WithMessage(ValidationErrors.StartUppercaseError);
			RuleFor(x => x.Year)
				.Must(x => !x.Any(z => z < 0)).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Stafs)
				.Must(x => !x.Any(z => z <= 0)).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Quality)
				.Must(x => !x.Any(z => z <= 0)).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Stafs)
				.Must(x => !x.Any(z => z <= 0)).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Genres)
				.Must(x => !x.Any(z => z <= 0)).WithMessage(ValidationErrors.GreaterZeroError);
			RuleFor(x => x.Country)
				.Must(x => !x.Any(z => z <= 0)).WithMessage(ValidationErrors.GreaterZeroError);
		}
	}
}
