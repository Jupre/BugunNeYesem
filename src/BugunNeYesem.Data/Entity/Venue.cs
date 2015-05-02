﻿using System;

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
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Likes { get; set; }
        public string Attributes { get; set; }

    }
}
