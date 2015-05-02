using NUnit.Framework;

using BugunNeYesem.Logic;

namespace BugunNeYesem.Test
{
    [TestFixture]
    public class LocationServiceTests
    {
        [Test]
        public void LocationService_GetLocation_ReturnsLocationResponse()
        {
            //arrange 
            const string argesetLatitude = "41.010305";
            const string argesetLongitude = "29.074330";

            var locationService = new LocationService();
            
            //act
            var result = locationService.GetLocation();

            //assert
            Assert.AreEqual(result.Latitude, argesetLatitude);
            Assert.AreEqual(result.Longitude, argesetLongitude);
        }
    }
}