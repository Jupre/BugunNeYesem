using System;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Logic.Recommenders
{
    public class DefaultRecommendationHistory : IRecommendationHistory
    {
        public bool RecommendedBefore(Venue venue, TimeSpan range)
        {
            return false;
        }
    }
}