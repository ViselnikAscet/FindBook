using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Language;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class LanguageDtoValidator : AbstractValidator<LanguageDto>
    {
        
        public LanguageDtoValidator()
        {            
        }

    }


}