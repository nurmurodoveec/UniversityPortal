using FluentValidation;
using UniversityPortalApi.Dto;

namespace UniversityPortalApi.Validators
{
    public class TimeTableValidator
    {
        public class TimetableValidator : AbstractValidator<TimetableDto>
        {
            public TimetableValidator()
            {
                RuleFor(t => t.StudentId)
                    .GreaterThan(0).WithMessage("Student ID must be a positive integer");

                RuleFor(t => t.SubjectId)
                    .GreaterThan(0).WithMessage("Subject ID must be a positive integer");
            }

            private bool BeAValidDate(DateTime date)
            {
                return date != default(DateTime);
            }
        }

    }
}
