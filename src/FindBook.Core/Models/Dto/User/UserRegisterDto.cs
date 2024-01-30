using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.User
{

    public class UserRegisterDto
    {
        
        public UserRegisterDto()
        {
            
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string ReEmail { get; set; }


    }


}