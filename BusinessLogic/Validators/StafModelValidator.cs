using BusinessLogic.Models;
using FluentValidation;



namespace BusinessLogic.Validators
{
	public class StafModelValidator : AbstractValidator<StafModel>
	{
		private readonly string notBeEmpty = "{PropertyName} not be empty";
        public StafModelValidator()
        {
            RuleFor(x => x.Id)
				 .NotNull().WithMessage(notBeEmpty)
				 .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal zero");
            RuleFor(x=>x.Birthdate)
                .NotEmpty().WithMessage(notBeEmpty)
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than today");
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage(notBeEmpty)
                 .Matches(@"^\p{Lu}.*").WithMessage("{PropertyName} must start with uppercase leter");
			RuleFor(x => x.Surname)
				 .NotEmpty().WithMessage(notBeEmpty)
				 .Matches(@"^\p{Lu}.*").WithMessage("{PropertyName} must start with uppercase leter");
			RuleFor(x => x.Description)
				 .NotEmpty().WithMessage(notBeEmpty)
				 .MinimumLength(20).WithMessage("{PropertyName} length must greater 20 symbols");
		    RuleFor(x => x.ImageFile)
				  .NotNull().When(x => String.IsNullOrEmpty(x.ImageName), ApplyConditionTo.CurrentValidator).WithMessage("{PropertyName} not be empty then ImageName is empty");
			RuleFor(x => x.IsOscar)
							 .NotNull().WithMessage(notBeEmpty);
		}
    }
}
