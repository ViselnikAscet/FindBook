using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.CampaignDetail;
using FluentValidation;

namespace FindBook.Core.Validation
{

    public class SimpleCampaignDetailDtoValidator : AbstractValidator<SimpleCampaignDetailDto>
    {
        
        public SimpleCampaignDetailDtoValidator()
        {            
        }

    }


}