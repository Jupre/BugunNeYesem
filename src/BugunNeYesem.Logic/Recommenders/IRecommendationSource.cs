using System.Collections.Generic;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Logic.Recommenders
{
    public interface IRecommendationSource
    {
        IEnumerable<Venue> List(int len);
    }
}