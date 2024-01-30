using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.User;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        
        public UserLoginDtoValidator()
        {            
            RuleFor(x => x.Username).NotEmpty().WithErrorCode("3010");
            RuleFor(x => x.Password).NotEmpty().WithErrorCode("3001");
            RuleFor(x => x.Username).NotNull().WithErrorCode("3010");
            RuleFor(x => x.Password).NotNull().WithErrorCode("3001");
        }

    }


}