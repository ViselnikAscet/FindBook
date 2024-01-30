using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.User
{

    public class BlogAuthorUserDto: BaseEntityDto
    {
        
        public BlogAuthorUserDto()
        {
            
        }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PermGroupId { get; set; }



    }


}