using System.Configuration;

using BugunNeYesem.Data;
using BugunNeYesem.Data.Helpers;
using BugunNeYesem.Logic.Utils;

namespace BugunNeYesem.Logic
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailSender _emailSender;

        public NotificationService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public bool NotifyFlowdockWithRecomendation(RecommendedRestaurant recommendedRestaurant)
        {
            var to = ConfigurationManager.AppSettings[ConstHelper.FLOWDOCK_CHANNEL_EMAIL];
            var subject = ConfigurationManager.AppSettings[ConstHelper.NOTIFY_MAIL_SUBJECT];
            var body = "<p>Haydi yemeğe gidelim :)<br/>Bugün <strong>" + recommendedRestaurant.RestaurantName + "</strong> tavsiye ediyorum..."
                       + "<br/><hr/><br/>"
                       + "<strong>sistem puanı:</strong> " + recommendedRestaurant.EditorRating + "<br/>"
                       + "<strong>adres:</strong> " + recommendedRestaurant.Address + "<br/>"
                       + "<strong>telefon:</strong> " + recommendedRestaurant.Phone + "<br/>"
                       + "</p>";

            _emailSender.Send(to, subject, body);

            return true;
        }
    }
}