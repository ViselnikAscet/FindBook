using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Entity
{

    public class MenuSection : BaseEntity
    {

        public MenuSection()
        {

        }
        public List<LanguageBasedInfo> LanguageBasedInfos { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int Priority { get; set; }


    }
}