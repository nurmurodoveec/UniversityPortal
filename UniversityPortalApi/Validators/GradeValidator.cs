using FluentValidation;
using UniversityPortalApi.Dto;

namespace UniversityPortalApi.Validators
{
    public class GradeValidator : AbstractValidator<CreateGradeDto>
    {
        public GradeValidator()
        {
            RuleFor(g => g.Score)
                .InclusiveBetween(0, 100).WithMessage("Grade must be between 0 and 100");
        }
    }

}
