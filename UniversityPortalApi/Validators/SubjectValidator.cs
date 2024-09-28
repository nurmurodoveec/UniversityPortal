using FluentValidation;
using UniversityPortalApi.Dto;

namespace UniversityPortalApi.Validators
{
    public class SubjectValidator : AbstractValidator<CreateSubjectDto>
    {
        public SubjectValidator()
        {
            RuleFor(s => s.SubjectName)
                .NotEmpty().WithMessage("Subject Name is required")
                .Length(3, 100).WithMessage("Subject Name must be between 3 and 100 characters");

            RuleFor(s => s.Credits)
                .InclusiveBetween(1, 6).WithMessage("Credit Hours must be between 1 and 6");

            
        }
    }

}
