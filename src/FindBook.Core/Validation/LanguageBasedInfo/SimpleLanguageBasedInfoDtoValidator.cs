using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleLangaugeBasedInfoDtoValidator : AbstractValidator<SimpleLanguageBasedInfoDto>
    {
        
        public SimpleLangaugeBasedInfoDtoValidator()
        {            
        }

    }


}