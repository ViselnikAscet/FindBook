using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.User;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        
        public UserDtoValidator()
        {            
        }

    }


}