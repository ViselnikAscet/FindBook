using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.User
{

    public class SimpleUserDto: BaseEntityDto
    {
        
        public SimpleUserDto()
        {
            
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }


}