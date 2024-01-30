using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Error;

namespace FindBook.Core.Models
{

    public class Request
    {
        
        public Request()
        {
            
        }
        public int LanguageId { get; set; }


    }
    public class Request<T> : Request
    {
        public T Data { get; set; }
    }


}