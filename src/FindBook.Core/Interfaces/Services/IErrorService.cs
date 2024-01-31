using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Interfaces.Services
{

    public interface IErrorService
    {
        Task<SimpleErrorDto> GetByCode(string code, int languageId);
        
    }


}