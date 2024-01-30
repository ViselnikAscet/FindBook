using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Error;

namespace FindBook.Core.Models
{

    public class Response
    {

        public Response()
        {
            IsSuccess = true;
            Errors = new List<SimpleErrorDto>();
        }
        public bool IsSuccess { get; set; }

        public List<SimpleErrorDto> Errors { get; set; }

    }
    public class Response<T> : Response
    {
        public T Data { get; set; }
    }


}