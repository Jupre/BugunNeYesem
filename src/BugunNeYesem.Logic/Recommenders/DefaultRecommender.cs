namespace BugunNeYesem.Logic.Recommenders
{
    public class DefaultRecommender : IRecommender
    {
        readonly IRecommendationSource _src;

        public DefaultRecommender(IRecommendationSource src)
        {
            _src = src;
        }
    }
}