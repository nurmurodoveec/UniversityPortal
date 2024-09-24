using FluentValidation;
using UniversityPortalApi.Dto;

namespace UniversityPortalApi.Validators
{
    public class NewsValidator : AbstractValidator<NewsDto>
    {
        public NewsValidator()
        {
            RuleFor(n => n.Title)
                .NotEmpty().WithMessage("News Title is required")
                .Length(5, 200).WithMessage("Title must be between 5 and 200 characters");

            RuleFor(n => n.Content)
                .NotEmpty().WithMessage("News Content is required")
                .MinimumLength(20).WithMessage("Content must be at least 20 characters long");

            RuleFor(n => n.PublishedDate)
                .NotEmpty().WithMessage("Published Date is required")
                .Must(BeAValidDate).WithMessage("Invalid date format");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime);
        }
    }

}
