using FluentValidation;
using Domain.Entities.DTOs;

namespace Application.Validators
{
    public class UpdateTeacherDTOValidator : AbstractValidator<UpdateTeacherDTO>
    {
        public UpdateTeacherDTOValidator()
        {
            RuleFor(x => x.TeacherID).GreaterThan(0).WithMessage("Teacher ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(x => x.Qualification)
                .NotEmpty().WithMessage("Qualification is required.")
                .Length(3, 200).WithMessage("Qualification must be between 3 and 200 characters.");

            RuleFor(x => x.Experience)
                .NotEmpty().WithMessage("Experience is required.")
                .Length(3, 500).WithMessage("Experience must be between 3 and 500 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Matches("^(Male|Female)$").WithMessage("Gender must be 'Male' or 'Female'.");

            RuleFor(x => x.PhoneNo)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");

            RuleFor(x => x.DoB)
                .NotNull().WithMessage("Date of Birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of Birth cannot be in the future.");
        }
    }
}
