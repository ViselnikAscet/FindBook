using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.User
{

    public class UserLoginDto
    {
        
        public UserLoginDto()
        {
            
        }
        public string Username { get; set; }
        public string Password { get; set; }


    }


}