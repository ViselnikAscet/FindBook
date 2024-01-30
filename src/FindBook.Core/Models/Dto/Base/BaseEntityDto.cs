using System;
using System.Collections.Generic;
using System.Linq;

namespace FindBook.Core.Models.Dto.Base
{

    public class BaseEntityDto
    {

        public BaseEntityDto()
        {
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }


}