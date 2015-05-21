using System;
using System.Configuration;
using BugunNeYesem.Data.Helpers;

namespace BugunNeYesem.Logic
{
    public class LocationService : ILocationService
    {
        public Location GetLocation()
        {
            var latitude = ConfigurationManager.AppSettings[ConstHelper.CURRENT_LATITUDE];
            if (string.IsNullOrWhiteSpace(latitude))
            {
                throw new Exception("CurrentLatitude not setted");
            }

            var longitude = ConfigurationManager.AppSettings[ConstHelper.CURRENT_LONGITUDE];
            if (string.IsNullOrWhiteSpace(longitude))
            {
                throw new Exception("CurrentLongitude not setted");
            }

            var location = new Location
            {
                Latitude = latitude,
                Longitude = longitude
            };
            return location;
        }
    }
}