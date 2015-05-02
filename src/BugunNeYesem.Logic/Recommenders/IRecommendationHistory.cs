using System;

namespace BugunNeYesem.Logic.Recommenders
{
    public interface IRecommendationHistory
    {
        bool RecommendedBefore(Venue venue, TimeSpan range);
    }
}