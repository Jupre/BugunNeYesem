﻿using System;
using System.Configuration;

namespace BugunNeYesem.Logic
{
    public class LocationService : ILocationService
    {
        public Location GetLocation()
        {
            var latitude = ConfigurationManager.AppSettings["CurrentLatitude"];
            if (string.IsNullOrWhiteSpace(latitude))
            {
                throw new Exception("CurrentLatitude not setted");
            }

            var longitude = ConfigurationManager.AppSettings["CurrentLongitude"];
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