namespace BugunNeYesem.Logic.Recommenders
{
    public class Venue
    {
        public decimal DistanceActual { get; set; }
        public decimal RatingEditorOverall { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2})", Name, RatingEditorOverall, DistanceActual);
        }

        public static Venue NotFound()
        {
            return new Venue()
            {
                Name = "NOT FOUND",
                DistanceActual = 0,
                RatingEditorOverall = 0
            };
        }
    }
}