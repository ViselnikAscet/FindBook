using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Book;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        
        public ProductDtoValidator()
        {            
        }

    }


}