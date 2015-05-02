﻿using System;
using BugunNeYesem.Data.Entity;
using BugunNeYesem.Logic.Recommenders;

namespace BugunNeYesem.Test
{
    internal class FakeRecommendationHistory : IRecommendationHistory
    {
        public bool RecommendedBefore(Venue venue, TimeSpan range)
        {
            return false;
        }
    }
}