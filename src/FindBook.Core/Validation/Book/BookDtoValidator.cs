using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Book;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        
        public BookDtoValidator()
        {            
        }

    }


}