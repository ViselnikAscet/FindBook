using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.Error
{

    public class SimpleErrorDto:BaseEntityDto
    {


        public string Code { get; set; }
        public string Message { get; set; }



    }


}