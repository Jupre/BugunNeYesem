using BugunNeYesem.Data;

namespace BugunNeYesem.Logic
{
    public interface INotificationService
    {
        bool NotifyFlowdockWithRecomendation(RecommendedRestaurant recommendedRestaurant);
    }
}