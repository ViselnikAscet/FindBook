using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class Error : BaseEntity
    {

        public Error()
        {

        }
        public string Code { get; set; }
        public string Message { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }


    }


}