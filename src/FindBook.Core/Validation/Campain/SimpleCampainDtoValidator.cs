using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.Campaign;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleCampaignDtoValidator : AbstractValidator<SimpleCampaignDto>
    {
        
        public SimpleCampaignDtoValidator()
        {            
        }

    }


}