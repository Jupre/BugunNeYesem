using BugunNeYesem.Data;
using BugunNeYesem.Logic;
using BugunNeYesem.Logic.Utils;

using FakeItEasy;
using NUnit.Framework;

namespace BugunNeYesem.Test
{
    [TestFixture]
    public class NotificationServiceTests
    {
        [Test]
        public void NotificationService_NotifyFlowdock_ReturnsTrue()
        {
            //arrange
            var emailSender = A.Fake<IEmailSender>();
            var notificationService = new NotificationService(emailSender);
            var recommendedRestaurant = new RecommendedRestaurant
            {
                RestaurantName = "Adres",
                Address = "Bulgurlu Mahallesi, Bulgurlu Caddesi, No 105/A, Üsküdar, İstanbul",
                Phone = "0 216 461 99 55",
                EditorRating = "4"
            };

            //act
            var result = notificationService.NotifyFlowdockWithRecomendation(recommendedRestaurant);

            //assert
            Assert.IsTrue(result);
        }
    }
}