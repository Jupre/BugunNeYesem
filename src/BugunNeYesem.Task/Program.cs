using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Logic;
using FourSquare.SharpSquare.Core;

namespace BugunNeYesem.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var locationService = new LocationService();
            var location = locationService.GetLocation();

            var clientId = "JZRZY54GMEWWZNT5CFFUIZAFYVEJMS20XODRLOREUZ5KLGJE";
            var clientSecret = "ENENFMHKR1HXJ0Y3VLTXJUNWTP2OGLTNNXSCT3KJ23JFIRWY";
            var sharpSquare = new SharpSquare(clientId, clientSecret);

            var ll = string.Format("{0},{1}", location.Latitude, location.Longitude);

            var venues = sharpSquare.SearchVenues(new Dictionary<string, string>
            {
                {"ll", ll},
                {"radius", "2000"}
            });
        }
    }
}
