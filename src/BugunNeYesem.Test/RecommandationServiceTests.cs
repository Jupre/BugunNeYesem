using System.Collections.Generic;
using BugunNeYesem.Logic.Recommenders;
using FakeItEasy;
using NUnit.Framework;

namespace BugunNeYesem.Test
{
    [TestFixture]
    public class RecommandationServiceTests
    {
        [Test]
        public void it_has_a_source()
        {
            var source = A.Fake<IRecommendationSource>();
            A.CallTo(() => source.List(50)).Returns(new List<string>()
            {
                "1",
                "2"
            });

            var recommender = new DefaultRecommender(source);
            Assert.IsNotNull(recommender);
        }

        [Test]
        public void it_can_recommend()
        {
            
        }

        
    }
}