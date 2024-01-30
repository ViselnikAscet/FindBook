using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class User: BaseEntity
    {
        
        public User()
        {
            
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
       
         public List<Blog> Blogs { get; set; }


    }


}