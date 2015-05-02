using System.Collections.Generic;

namespace BugunNeYesem.Logic.Recommenders
{
    public interface IRecommendationSource
    {
        IEnumerable<string> List(int len);
    }
}