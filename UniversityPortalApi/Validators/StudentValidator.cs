using FluentValidation;
using UniversityPortalApi.Dto;

public class StudentValidator : AbstractValidator<CreateStudentDto>
{
    public StudentValidator()
    {
        RuleFor(s => s.FirstName)
            .NotEmpty().WithMessage("First Name is required")
            .Matches(@"^[a-zA-Z]+$").WithMessage("First Name must contain only letters");

        RuleFor(s => s.LastName)
            .NotEmpty().WithMessage("Last Name is required")
            .Matches(@"^[a-zA-Z]+$").WithMessage("Last Name must contain only letters");

        RuleFor(s => s.EnrollmentYear)
            .InclusiveBetween(2000, 2024).WithMessage("Enrollment Year must be between 2000 and 2024");
    }
}

