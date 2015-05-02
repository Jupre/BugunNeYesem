using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Data.Repository
{
    public class VenueRepository : Repository<Venue>
    {
         public VenueRepository(BugunNeYesemDbContext context) : base(context)
            { }
    }
}
