using System;

namespace BugunNeYesem.Data.Entity
{
    public class Venue : BaseEntity
    {
        public string FoursquareVenueId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Likes { get; set; }
        public string Attributes { get; set; }

        public decimal DistanceActual { get; set; }
        public decimal Rating { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2})", Name, Rating, DistanceActual);
        }

        public static Venue NotFound()
        {
            return new Venue()
            {
                Name = "NOT FOUND",
                DistanceActual = 0,
                Rating = 0
            };
        }

        public Venue()
        {
            DistanceActual = 5;
        }
    }
}
