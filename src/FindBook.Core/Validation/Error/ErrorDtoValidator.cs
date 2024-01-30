using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Error;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class ErrorDtoValidator : AbstractValidator<ErrorDto>
    {
        
        public ErrorDtoValidator()
        {            
        }

    }


}