using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Language;

namespace FindBook.Core.Interfaces.Services
{

    public interface ILanguageService:IBaseService<LanguageDto>
    {
        Task<Response<LanguageDto>> GetDefault();
        Task<Response<List<LanguageDto>>> GetAllLanguage(int languageId);

    }


}