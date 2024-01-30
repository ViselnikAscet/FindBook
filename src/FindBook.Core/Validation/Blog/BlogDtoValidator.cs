using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Blog;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class BlogDtoValidator : AbstractValidator<BlogDto>
    {
        
        public BlogDtoValidator()
        {            
        }

    }


}