using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.ProductCategory;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleProductCategoryDtoValidator : AbstractValidator<SimpleProductCategoryDto>
    {
        
        public SimpleProductCategoryDtoValidator()
        {            
        }

    }


}