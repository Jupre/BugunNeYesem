using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BugunNeYesem.Logic.Recommenders
{
    public class DefaultRecommender : IRecommender
    {
        static new Random _random = new Random(System.Environment.TickCount);
        readonly IRecommendationSource _src;
        private readonly IRecommendationHistory _history;

        public DefaultRecommender(IRecommendationSource src, IRecommendationHistory history)
        {
            _src = src;
            _history = history;
        }

        // Zomatada bulunan 1.5 km çaptaki 5 yıldızdan aşağıya doğru 8 venue ve 0 yıldız olan 2 venuenun içerisinden random öneri yapması gerekiyor.
        // 2 Adet 0 yıldız venuenun getirilmesinin sebebi öneriler gelirken yeni açılan restauranlar (0 yıldız venue) arada sırada önerilmesidir.
        // Bu 10 venue yu seçerken bir hafta içerisinde önerilenlerin içerisinden çıkarılması gerekiyor.
        // Son 15 gün içerisinde 0 yıldız herhangi bir restaruanta gidilmemiş ise random venue seçimi yapılırken 8 çok yıldızlılar göz arda edilerek 2 adet 0 yıldızlıdan bir tanesinin önerilmesi bekleniyor. Böylelikle 15 günde bir yeni mekanlar keşfedilme imkanı olacak.
        public Venue Recommend()
        {
            IEnumerable<Venue> allVenues = _src.List(25);

            var eightRatedVenues = new List<Venue>();
            var zeroRatedVenues = new List<Venue>();
            
            foreach (var v in allVenues)
            {
                if (_history.RecommendedBefore(v, TimeSpan.FromDays(15))) continue;
                
                if (v.DistanceActual > 1.5m) continue;

                if (v.RatingEditorOverall >= 5)
                {
                    eightRatedVenues.Add(v);
                    continue;
                }
                
                if (v.RatingEditorOverall == 0)
                {
                    zeroRatedVenues.Add(v);
                    continue;
                }
            }

            return Randomize(eightRatedVenues.Take(8).Concat(zeroRatedVenues.Take(2)));
        }

        private Venue Randomize(IEnumerable<Venue> venues)
        {
            if (venues.Count() == 0) return Venue.NotFound();
            
            string str = "";
            foreach (var v in venues) str += v + " ";
            Debug.WriteLine(string.Format("Randomizing from : {0}", str));
            var next = _random.Next(0, venues.Count());
            
            return venues.Skip(next).Take(1).First();
        }
    }
}