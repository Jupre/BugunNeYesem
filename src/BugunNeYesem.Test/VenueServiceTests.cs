using System.Xml.Serialization;
using BugunNeYesem.Logic;
using BugunNeYesem.Logic.VenueServices;
using NUnit.Framework;

namespace BugunNeYesem.Test
{
    [TestFixture]
    public class VenueServiceTests
    {
        [Test]
        public void get_venues()
        {
            var locationService = new LocationService();
            var location = locationService.GetLocation();

            var service = new VenueService();

            var venues = service.GetVenues(location);

            Assert.IsNotEmpty(venues);
        }
    }
}