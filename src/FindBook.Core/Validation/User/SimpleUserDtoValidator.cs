using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.User;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleUserDtoValidator : AbstractValidator<SimpleUserDto>
    {
        
        public SimpleUserDtoValidator()
        {            
        }

    }


}