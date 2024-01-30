using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class Resource : BaseEntity
    {

        public Resource()
        {

        }
        public string Key { get; set; }
        public string Value { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

    }


}