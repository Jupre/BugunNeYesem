using System.Collections.Generic;

namespace BugunNeYesem.Logic.Recommenders
{
    public interface IRecommendationSource
    {
        IEnumerable<Venue> List(int len);
    }
}