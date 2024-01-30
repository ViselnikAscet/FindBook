using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class Language : BaseEntity
    {

        public Language()
        {

        }
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public bool IsDefault { get; set; }
        public List<LanguageBasedInfo> LanguageBasedInfo { get; set; }
        public List<SeoInfo> SeoInfos { get; set; }
        public List<Error> Errors { get; set; }
        public List<Resource> Resources { get; set; }




    }


}