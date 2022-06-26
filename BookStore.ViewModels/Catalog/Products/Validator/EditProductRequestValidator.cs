using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products.Validator
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        public EditProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                        .Length(0, 128).WithMessage("Name cannot over 200 character");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");

            RuleFor(x => x.OriginalPrice).NotEmpty().WithMessage("Original Price is required");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required").
                InclusiveBetween(0, 10000);

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Details).NotEmpty().WithMessage("Details is required");

            RuleFor(x => x.SeoDescription).NotEmpty().WithMessage("SeoDescription is required")
                        .Length(0, 128).WithMessage("LastName cannot over 200 character");

            RuleFor(x => x.SeoTitle).NotEmpty().WithMessage("SeoTitle is required");

            RuleFor(x => x.SeoAlias).NotEmpty().WithMessage("SeoAlias is required");
        }
    }
}