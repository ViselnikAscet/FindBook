using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class Token : BaseEntity
    {

        public Token()
        {

        }
        public string AccessToken { get; set; }
        public int ModuleCode { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int ExpiredInt { get; set; }


    }


}