using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Product;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleProductDtoValidator : AbstractValidator<SimpleProductDto>
    {
        
        public SimpleProductDtoValidator()
        {            
        }

    }


}