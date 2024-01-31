using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.BookCategory;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class BookCategoryDtoValidator : AbstractValidator<BookCategoryDto>
    {
        
        public BookCategoryDtoValidator()
        {            
        }

    }


}