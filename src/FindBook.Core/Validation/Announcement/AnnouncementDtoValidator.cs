using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Announcement;

using FluentValidation;

namespace FindBook.Core.Validation.Announcement
{

    public class AnnouncementDtoValidator : AbstractValidator<AnnouncementDto>
    {

        public AnnouncementDtoValidator()
        {

        }

    }


}