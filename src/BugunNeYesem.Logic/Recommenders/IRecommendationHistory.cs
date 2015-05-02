using System;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Logic.Recommenders
{
    public interface IRecommendationHistory
    {
        bool RecommendedBefore(Venue venue, TimeSpan range);
    }
}