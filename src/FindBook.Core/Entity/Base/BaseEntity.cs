using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindBook.Core.Entity.Base
{
    public class BaseEntity
    {
        public BaseEntity()
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