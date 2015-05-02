using System;

namespace BugunNeYesem.Data.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

    }
}
