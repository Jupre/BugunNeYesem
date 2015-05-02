using System.Collections.Generic;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Logic.VenueServices
{
    public interface IVenueService
    {
        IEnumerable<Venue> GetVenues(Location location, string radius = "2000");
    }
}
