using System;
using System.Collections.Generic;
using BugunNeYesem.Logic.Recommenders;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using NUnit.Framework;

namespace BugunNeYesem.Test
{
    [TestFixture]
    public class RecommandationServiceTests
    {
        [Test]
        public void it_has_a_source()
        {
            var source = FakeSource();
            var recommender = new DefaultRecommender(source, new FakeRecommendationHistory());
            Assert.IsNotNull(recommender);
        }

        [Test]
        public void it_can_recommend()
        {
            var recommender = new DefaultRecommender(FakeSource(), new FakeRecommendationHistory());
            var venue = recommender.Recommend();
            Console.WriteLine(venue.Name);
        }

        static IRecommendationSource FakeSource()
        {
            var source = A.Fake<IRecommendationSource>();
            A.CallTo(() => source.List(25)).Returns(new List<Venue>()
            {
                new Venue () {Name = "POPULAR-FISH", RatingEditorOverall = 10, DistanceActual = 2},
                new Venue () {Name = "POPULAR-MEAT", RatingEditorOverall = 10, DistanceActual = 2},
                new Venue () {Name = "NORMAL-FISH", RatingEditorOverall = 8, DistanceActual = 2},
                new Venue () {Name = "NORMAL-MEAT", RatingEditorOverall = 8, DistanceActual = 2},
                new Venue () {Name = "BAD-FISH", RatingEditorOverall = 5, DistanceActual = 2},
                new Venue () {Name = "BAD-MEAT", RatingEditorOverall = 5, DistanceActual = 2},
                new Venue () {Name = "DISTANT-FISH", RatingEditorOverall = 5, DistanceActual = 5},
                new Venue () {Name = "DISTANT-MEAT", RatingEditorOverall = 5, DistanceActual = 5},
                new Venue () {Name = "NEW-FISH", RatingEditorOverall = 0, DistanceActual = 5},
                new Venue () {Name = "NEW-MEAT", RatingEditorOverall = 0, DistanceActual = 5}
            });
            return source;
        }
    }
}