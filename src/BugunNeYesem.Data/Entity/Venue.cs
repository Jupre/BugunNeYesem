using System;

namespace BugunNeYesem.Data.Entity
{
    public class Venue : BaseEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string Attributes { get; set; }

    }
}
