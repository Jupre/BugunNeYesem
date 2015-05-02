using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        public IEnumerable<string> GetVenues(Location location, string radius = "2000")
        {
            var ll = string.Format("{0},{1}", location.Latitude, location.Longitude);

            var venues = _sharpSquare.SearchVenues(new Dictionary<string, string>
            {
                {"ll", ll},
                {"radius", radius}
            });

            return venues.Select(x => x.name);
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