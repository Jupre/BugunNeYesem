using System;

namespace BugunNeYesem.Data.Entity
{
    public class Recommendation : BaseEntity
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
    }
}
