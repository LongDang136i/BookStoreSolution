using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.System.Users.Validators
{
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
                    .MaximumLength(200).WithMessage("FirstName cannot over 200 character");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
                    .MaximumLength(200).WithMessage("LastName cannot over 200 character");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
        }
    }
}