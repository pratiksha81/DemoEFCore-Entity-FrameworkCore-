using Domain.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.DTOs;
using FluentValidation;

namespace Application.Validators
    {
        public class CreateTeacherDTOValidator : AbstractValidator<CreateTeacherDTO>
        {
            public CreateTeacherDTOValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required")
                    .MaximumLength(255).WithMessage("Name cannot exceed 255 characters");

                RuleFor(x => x.Qualification)
                    .NotEmpty().WithMessage("Qualification is required")
                    .MaximumLength(255).WithMessage("Qualification cannot exceed 255 characters");

                RuleFor(x => x.Experience)
                    .NotEmpty().WithMessage("Experience is required")
                    .MaximumLength(255).WithMessage("Experience cannot exceed 255 characters");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required")
                    .EmailAddress().WithMessage("Invalid email format")
                    .MaximumLength(255).WithMessage("Email cannot exceed 255 characters");

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required")
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                    .Matches("[0-9]").WithMessage("Password must contain at least one digit")
                    .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

                RuleFor(x => x.DoB)
                    .NotEmpty().WithMessage("Date of Birth is required");

                RuleFor(x => x.Gender)
                    .NotEmpty().WithMessage("Gender is required")
                    .MaximumLength(255).WithMessage("Gender cannot exceed 255 characters");

                RuleFor(x => x.PhoneNo)
                    .NotEmpty().WithMessage("Phone Number is required")
                    .Matches(@"^9[78]\d{8}$").WithMessage("Phone number must start with 97 or 98 and have exactly 10 digits")
                    .MaximumLength(255).WithMessage("Phone number cannot exceed 255 characters");
            }
        }
    }


