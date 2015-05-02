using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Data;
using BugunNeYesem.Data.Entity;
using BugunNeYesem.Logic;
using BugunNeYesem.Logic.Recommenders;
using BugunNeYesem.Logic.Utils;
using BugunNeYesem.Logic.VenueServices;
using FourSquare.SharpSquare.Core;

namespace BugunNeYesem.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var locationService = new LocationService();
            var location = locationService.GetLocation();

            var venueService = new VenueService();
            var venues = venueService.GetVenues(location);

            var defaultRecommender = new DefaultRecommender(new DefaultRecommendationHistory());
            var recommend = defaultRecommender.Recommend(venues);

            var recommendedRestaurant = new RecommendedRestaurant {RestaurantName = recommend.Name};
            var notificationService = new NotificationService(new EmailSender());

            notificationService.NotifyFlowdockWithRecomendation(recommendedRestaurant);
        }
    }
}
