using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Categories.Validator
{
    public class CategoryUpdateRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public CategoryUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                        .Length(0, 128).WithMessage("Name cannot over 200 character");

            RuleFor(x => x.SortOrder).NotEmpty().WithMessage("Sort Order is required");

            RuleFor(x => x.SortOrder).NotEmpty().WithMessage("Is show On Home is required");

            RuleFor(x => x.SeoDescription).NotEmpty().WithMessage("SeoDescription is required");

            RuleFor(x => x.SeoTitle).NotEmpty().WithMessage("SeoTitle is required");

            RuleFor(x => x.SeoAlias).NotEmpty().WithMessage("SeoAlias is required");
        }
    }
}