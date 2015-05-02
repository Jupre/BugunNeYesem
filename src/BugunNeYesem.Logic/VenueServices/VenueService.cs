using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BugunNeYesem.Data.Entity;
using FourSquare.SharpSquare.Core;

namespace BugunNeYesem.Logic.VenueServices
{
    public class VenueService : IVenueService
    {
        private readonly SharpSquare _sharpSquare;
        public VenueService()
        {
            _sharpSquare = new SharpSquare(ClientId, ClientSecret);
        }

        public IEnumerable<Venue> GetVenues(Location location, string radius = "2000")
        {
            var ll = string.Format("{0},{1}", location.Latitude, location.Longitude);

            var venues = _sharpSquare.SearchVenues(new Dictionary<string, string>
            {
                {"ll", ll},
                {"radius", radius}
            });

            return venues.Select(MapVenue);
        }

        private static Venue MapVenue(FourSquare.SharpSquare.Entities.Venue venue)
        {
            return new Venue
            {
                Name = venue.name,
                Price = venue.price != null ? Convert.ToDecimal(venue.price.tier) : 0.0m,
                Rating = Convert.ToDecimal(venue.rating),
                Url = venue.url,
                Location = string.Format("lat:{0}, log:{1}", venue.location.lat, venue.location.lng),
                Contact = string.Format("name:{0}, phone:{1}", venue.contact.name, venue.contact.phone)
                //Likes = venue.likes.count
                //Description = venue.description,
                //CreatedAt = Convert.ToDateTime(venue.createdAt)
            };
        }


        private static string ClientSecret
        {
            get
            {
                var clientSecret = ConfigurationManager.AppSettings["FoursquareClientSecret"];
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    throw new Exception("FoursquareClientSecret not setted");
                }
                return clientSecret;
            }
        }

        private static string ClientId
        {
            get
            {
                var clientId = ConfigurationManager.AppSettings["FoursquareClientId"];
                if (string.IsNullOrWhiteSpace(clientId))
                {
                    throw new Exception("FoursquareClientId not setted");
                }
                return clientId;
            }
        }
    }
}