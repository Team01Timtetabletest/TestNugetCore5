using System;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public BaseEntity()
        {
            CreatedDateTime = DateTime.UtcNow;
            LastModifiedDateTime = DateTime.UtcNow;
        }
    }
}