using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugunNeYesem.Logic.VenueServices
{
    public interface IVenueService
    {
        IEnumerable<string> GetVenues(Location location, string radius = "2000");
    }
}
